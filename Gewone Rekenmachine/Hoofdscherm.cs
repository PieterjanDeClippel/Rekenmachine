using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Gewone_Rekenmachine
{
	public partial class Hoofdscherm : Form
	{
		public Hoofdscherm()
		{
			InitializeComponent();
			
			digits = new List<char>();
			for(char i = '0'; i <= '9'; i++)
				digits.Add(i);
			for(char i = 'A'; i <= 'Z'; i++)
				digits.Add(i);
			frmInfoLabel.Owner = this;

			FlatStyle st = (FlatStyle)Properties.Settings.Default.Stijl;
			switch(st)
			{
				case FlatStyle.Flat:
					rbnStijlFlat.Checked = true;
					break;
				case FlatStyle.Popup:
					rbnStijlPopup.Checked = true;
					break;
				case FlatStyle.Standard:
					rbnStijlStandard.Checked = true;
					break;
				case FlatStyle.System:
					rbnStijlSystem.Checked = true;
					break;
			}
			SetStyleToChildren(st, this);
		}
		List<char> digits;

		public double NaarDecimaal(string waarde, int talstelsel)
		{
			bool neg = waarde.StartsWith("-");
			if(neg) waarde = waarde.Substring(1);

			string geheel = (string)waarde.Split(komma[0])[0].Reverse().ToString();
			string decimaal = waarde.Contains(komma) ? waarde.Split(komma[0])[1] : "";
			double resultaat = 0;

			for(int i = 0; i < geheel.Length; i++)
				resultaat += ((double)digits.IndexOf(geheel[i])) * Math.Pow(talstelsel, i);

			for(int i = 0; i < decimaal.Length; i++)
				resultaat += digits.IndexOf(decimaal[i]) / Math.Pow(talstelsel, i + 1);
			return (neg ? -1 : 1) * resultaat;
		}

		public string VanDecimaal(double waarde, int talstelsel)
		{
			if(talstelsel == 10) return waarde.ToString();
			string resultaat = "";
			waarde = Convert.ToDouble(waarde.ToString());
			bool neg = waarde < 0;
			waarde = Math.Abs(waarde);

			string[] decdeel = waarde.ToString().Split(komma[0]);
			double decimaal = decdeel.Length < 2 ? 0 : Convert.ToDouble("0" + komma + decdeel[1]);
			double geheel = (double)((int)(waarde - decimaal));

			while(geheel != 0)
			{
				resultaat = digits[(int)(geheel % (double)talstelsel)] + resultaat;
				geheel = (geheel - geheel % (double)talstelsel) / (double)talstelsel;
			}

			if(resultaat == "") resultaat = "0";
			if(decimaal != 0)
			{
				resultaat += komma;
				for(double i = 1 / (double)talstelsel; decimaal > double.Epsilon; i /= talstelsel)
				{
					resultaat += digits[Convert.ToInt16((decimaal - decimaal % i) / i)];
					decimaal %= i;
				}
			}
			return (neg ? "-" : "") + resultaat;
		}

		public void ZoekGetallen(string bewerking, int talstelsel, int startindex, out string format, out double[] getallen)
		{
			// (\-)*(
			//       ([0-9A-Z]+([.]*[0-9A-Z]+)*)
			//    |  (\b([a-z]+)\b)(?!\()
			// )
			string txt = @"(((\-)*)(\b([0-9A-Z]+([" + komma + @"]*[0-9A-Z]*)*)|([a-z]+)(?!\()\b))";
			Regex rgx = new Regex(txt);

			List<double> lstGetallen = new List<double>();
			List<string> lstResidus = new List<string>();
			int last = 0;

			MatchCollection col = rgx.Matches(bewerking);
			foreach(Match match in col)
			{
				bool param = false;
				switch(match.Value)
				{
					case "-pi":
						lstGetallen.Add(-Math.PI);
						break;
					case "-e":
						lstGetallen.Add(-Math.E);
						break;
					case "pi":
						lstGetallen.Add(Math.PI);
						break;
					case "e":
						lstGetallen.Add(Math.E);
						break;
					default:
						if(match.Value.Count(c => Char.IsLower(c)) == match.Value.Length)
							param = true;
						else
							lstGetallen.Add(NaarDecimaal(match.Value, talstelsel));
						break;
				}
				if(!param)
				{
					lstResidus.Add(match.Index == 0 ? "" : bewerking.Substring(last, match.Index - last));
					last = match.Index + match.Length;
				}
			}

			if(last != bewerking.Length)
			{
				lstResidus.Add(bewerking.Substring(last));
			}
			else
			{
				lstResidus.Add("");
			}

			getallen = lstGetallen.ToArray();
			string strFormat = "";
			int counter = startindex;
			for(int i = 0; i < lstGetallen.Count; i++)
			{
				strFormat += lstResidus[i];
				strFormat += "‘" + counter++.ToString() + "’";
			}
			strFormat += lstResidus.Last();
			format = strFormat;
		}

		public int GetTalstelsel()
		{
			if(rbnBinair.Checked) return 2;
			if(rbnOctaal.Checked) return 8;
			if(rbnHexadecimaal.Checked) return 16;
			return 10;
		}

		double UITKOMST;
		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				double[] getallen;
				string format;
				ZoekGetallen(txtBewerking.Text, GetTalstelsel(), 0, out format, out getallen);

				enHoekmaat hoek;
				if(rbnGraden.Checked) hoek = enHoekmaat.Graden;
				else if(rbnGon.Checked) hoek = enHoekmaat.Gradienten;
				else hoek = enHoekmaat.Radialen;

				UITKOMST = BerekenFuncties(format, getallen.ToList(), true, hoek);
				txtUitkomst.Text = VanDecimaal(UITKOMST, GetTalstelsel());
				frmInfoLabel.Visible = false;
				panel5.AutoScrollPosition = new Point();
				// 26*34^15+12
			}
			catch(Exception ex)
			{
			}
		}

		string komma = CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator;
		Dictionary<double, double> Geheugen = new Dictionary<double, double>();

		byte[] key = new byte[] { 145, 115, 204, 18, 169, 243, 250, 105, 39, 138, 185, 220, 40, 26, 170, 245, 197, 6, 10, 197, 197, 63, 70, 94, 112, 51, 156, 86, 54, 110, 252, 225 };
		byte[] IV = new byte[] { 244, 50, 208, 23, 38, 58, 11, 60, 87, 120, 171, 126, 57, 59, 26, 142 };

		public double BerekenFuncties(string bewerking, List<double> getallen, bool store, enHoekmaat hoek)
		{
			bewerking = bewerking.Replace(" ", "");
			int haakjestekort = bewerking.Count(T => T == '(') - bewerking.Count(T => T == ')');
			if(haakjestekort < 0)
			{
				MessageBox.Show("Fout 1");
				return double.NaN;
			}
			else
			{
				//System.IO.File.SetAttributes(, System.IO.FileAttributes.Encrypted)
				for(int i = 0; i < haakjestekort; i++) bewerking += ')';
				Regex rgx = new Regex(@"[a-z]+\(");
				foreach(Match m in rgx.Matches(bewerking).Reverse())
				{
					#region Bepalen opgegeven parameters (paramList)
					int level = 0;
					int lastToken = m.Index + m.Length - 1;
					List<double> paramlist = new List<double>(); paramlist.Clear();
					int einde_functie = 0;
					for(int i = m.Index + m.Length; i < bewerking.Length; i++)
					{
						switch(bewerking[i])
						{
							case '(':
								level++;
								break;
							case ')':
								if(--level < 0)
								{
									string txt = bewerking.Substring(lastToken + 1, i - 1 - lastToken);
									paramlist.Add(txt == "" ? double.NaN : BerekenHaakjes(txt, getallen, store));
									einde_functie = i;
									goto break_for;
								}
								break;
							case ';':
								if(level == 0)
								{
									string txt = bewerking.Substring(lastToken + 1, i - 1 - lastToken);
									paramlist.Add(txt == "" ? double.NaN : BerekenHaakjes(txt, getallen, store));
									lastToken = i;
								}
								break;
						}
					}

					// we hebben de parameters in paramlist
					// indien parameter niet opgegeven --> NaN


					#endregion
					break_for: Application.DoEvents();
					string src = bewerking.Substring(m.Index, einde_functie - m.Index + 1);
					switch(m.Value.Remove(m.Length - 1))
					{
						#region Standaard Functies
						case "sin":
							getallen.Add(Math.Sin(paramlist[0]));
							break;
						case "cos":
							getallen.Add(Math.Cos(paramlist[0]));
							break;
						case "tan":
							getallen.Add(Math.Tan(paramlist[0]));
							break;
						case "sind":
							getallen.Add(Math.Sin(paramlist[0] / 180 * Math.PI));
							break;
						case "cosd":
							getallen.Add(Math.Cos(paramlist[0] / 180 * Math.PI));
							break;
						case "tand":
							getallen.Add(Math.Tan(paramlist[0] / 180 * Math.PI));
							break;
						case "sing":
							getallen.Add(Math.Sin(paramlist[0] / 200 * Math.PI));
							break;
						case "cosg":
							getallen.Add(Math.Cos(paramlist[0] / 200 * Math.PI));
							break;
						case "tang":
							getallen.Add(Math.Tan(paramlist[0] / 200 * Math.PI));
							break;
						case "csc":
							getallen.Add(1 / Math.Sin(paramlist[0]));
							break;
						case "sec":
							getallen.Add(1 / Math.Cos(paramlist[0]));
							break;
						case "cot":
							getallen.Add(1 / Math.Tan(paramlist[0]));
							break;
						case "cscd":
							getallen.Add(1 / Math.Sin(paramlist[0] / 180 * Math.PI));
							break;
						case "secd":
							getallen.Add(1 / Math.Cos(paramlist[0] / 180 * Math.PI));
							break;
						case "cotd":
							getallen.Add(1 / Math.Tan(paramlist[0] / 180 * Math.PI));
							break;
						case "cscg":
							getallen.Add(1 / Math.Sin(paramlist[0] / 200 * Math.PI));
							break;
						case "secg":
							getallen.Add(1 / Math.Cos(paramlist[0] / 200 * Math.PI));
							break;
						case "cotg":
							getallen.Add(1 / Math.Tan(paramlist[0] / 200 * Math.PI));
							break;
						case "bgsin":
							getallen.Add(Math.Asin(paramlist[0]));
							break;
						case "bgcos":
							getallen.Add(Math.Acos(paramlist[0]));
							break;
						case "bgtan":
							getallen.Add(Math.Atan(paramlist[0]));
							break;
						case "bgsind":
							getallen.Add(Math.Asin(paramlist[0]) / Math.PI * 180);
							break;
						case "bgcosd":
							getallen.Add(Math.Acos(paramlist[0]) / Math.PI * 180);
							break;
						case "bgtand":
							getallen.Add(Math.Atan(paramlist[0]) / Math.PI * 180);
							break;
						case "bgsing":
							getallen.Add(Math.Asin(paramlist[0]) / Math.PI * 200);
							break;
						case "bgcosg":
							getallen.Add(Math.Acos(paramlist[0]) / Math.PI * 200);
							break;
						case "bgtang":
							getallen.Add(Math.Atan(paramlist[0]) / Math.PI * 200);
							break;
						case "bgcsc":
							getallen.Add(Math.Asin(1 / paramlist[0]));
							break;
						case "bgsec":
							getallen.Add(Math.Acos(1 / paramlist[0]));
							break;
						case "bgcot":
							getallen.Add(Math.Atan(1 / paramlist[0]));
							break;
						case "bgcscd":
							getallen.Add(Math.Asin(1 / paramlist[0]) / Math.PI * 180);
							break;
						case "bgsecd":
							getallen.Add(Math.Acos(1 / paramlist[0]) / Math.PI * 180);
							break;
						case "bgcotd":
							getallen.Add(Math.Atan(1 / paramlist[0]) / Math.PI * 180);
							break;
						case "bgcscg":
							getallen.Add(Math.Asin(1 / paramlist[0]) / Math.PI * 200);
							break;
						case "bgsecg":
							getallen.Add(Math.Acos(1 / paramlist[0]) / Math.PI * 200);
							break;
						case "bgcotg":
							getallen.Add(Math.Atan(1 / paramlist[0]) / Math.PI * 200);
							break;
						case "sinh":
							getallen.Add(Math.Sinh(paramlist[0]));
							break;
						case "cosh":
							getallen.Add(Math.Cosh(paramlist[0]));
							break;
						case "tanh":
							getallen.Add(Math.Tanh(paramlist[0]));
							break;
						case "csch":
							getallen.Add(1 / Math.Sinh(paramlist[0]));
							break;
						case "sech":
							getallen.Add(1 / Math.Cosh(paramlist[0]));
							break;
						case "coth":
							getallen.Add((Math.Exp(paramlist[0]) + Math.Exp(-paramlist[0])) / (Math.Exp(paramlist[0]) - Math.Exp(-paramlist[0])));
							break;
						case "bgsinh":
							getallen.Add(Math.Log(paramlist[0] + Math.Sqrt(1 + Math.Pow(paramlist[0], 2))));
							break;
						case "bgcosh":
							getallen.Add(Math.Log(paramlist[0] + Math.Sqrt(paramlist[0] + 1) * Math.Sqrt(paramlist[0] - 1)));
							break;
						case "bgtanh":
							getallen.Add(0.5 * (Math.Log(1 + paramlist[0]) - Math.Log(1 - paramlist[0])));
							break;
						case "bgcsch":
							double w2 = 1 / paramlist[0];
							getallen.Add(Math.Log(w2 + Math.Sqrt(1 + Math.Pow(w2, 2))));
							break;
						case "bgsech":
							getallen.Add(Math.Log(Math.Sqrt(1 / paramlist[0] - 1) * Math.Sqrt(1 / paramlist[0] + 1) + 1 / paramlist[0]));
							break;
						case "bgcoth":
							getallen.Add(0.5 * (Math.Log(1 + 1 / paramlist[0]) - Math.Log(1 - 1 / paramlist[0])));
							break;
						case "ln":
							getallen.Add(Math.Log(paramlist[0]));
							break;
						case "exp":
							getallen.Add(Math.Exp(paramlist[0]));
							break;
						case "log":
							if(paramlist.Count == 1)
								getallen.Add(Math.Log(paramlist[0], 10));
							else if(paramlist.Count == 2)
								getallen.Add(Math.Log(paramlist[0], paramlist[1]));
							break;
						case "abs":
							getallen.Add(Math.Abs(paramlist[0]));
							break;
						case "rcl":
							getallen.Add(Geheugen[paramlist[0]]);
							break;
						case "if":
							if(paramlist[0] == 0)
								getallen.Add(paramlist.Count > 2 ? paramlist[2] : 0);
							else
								getallen.Add(paramlist[1]);
							break;
						#endregion
						default:
							#region Bestand inlezen
							string bestand = mapnaam_func + m.Value.Remove(m.Length - 1) + ".func";
							FileStream fs = new FileStream(bestand, FileMode.Open);

							Rijndael rijAlg = Rijndael.Create();
							ICryptoTransform decryptor = rijAlg.CreateDecryptor(key, IV);

							CryptoStream cs = new CryptoStream(fs, decryptor, CryptoStreamMode.Read);
							StreamReader reader = new StreamReader(cs);
							string tekst = reader.ReadToEnd();
							reader.Close();
							string[] blokken = tekst.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None);

							string functie_type = blokken[0].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0];
							string functie_voorschrift = blokken[0].Split(new string[] { "\r\n" }, StringSplitOptions.None)[2];
							string[] functie_parameters = blokken[1].Split(new string[] { "\r\n" }, StringSplitOptions.None);
							string[] functie_temps = blokken[2].Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
							#endregion
							#region Input-parameters aanvullen (optionele params)
							for(int i = 0; i < functie_parameters.Length; i++)
							{
								string param_lijn = functie_parameters[i];
								string[] parts = param_lijn.Split(';');
								if(double.IsNaN(paramlist[i]))
								{
									// optioneel ?
									if(parts[3] == "1")
									{
										if(paramlist.Count - 1 < i)
											paramlist.Add(Convert.ToDouble(parts[4]));
										else
											paramlist[i] = Convert.ToDouble(parts[4]);
									}
									else
									{
										throw new Exception("De parameter \"" + parts[0] + "\" is niet opgegeven en is niet gemarkeerd als optioneel");
									}
								}
							}
							#endregion

							int teller = paramlist.Count;

							#region Constanten vervangen
							double[] constanten;
							ZoekGetallen(functie_voorschrift, talstelsel, teller, out functie_voorschrift, out constanten);
							paramlist.AddRange(constanten);
							teller += constanten.Length;
							#endregion
							#region Temps
							foreach(string t in functie_temps)
							{
								string temp_voorschrift = t.Split(';')[2];
								int temp_teller = 0;
								List<double> temp_waarden = new List<double>();

								#region Constanten vervangen
								double[] temp_const;
								ZoekGetallen(temp_voorschrift, talstelsel, 0, out temp_voorschrift, out temp_const);
								temp_waarden.AddRange(temp_const);
								temp_teller += temp_const.Length;
								#endregion
								#region Parameters vervangen
								for(int i = 0; i < functie_parameters.Length; i++)
								{
									Regex rgx2 = new Regex("\\b" + functie_parameters[i].Split(';')[0] + "\\b");
									temp_voorschrift = rgx2.Replace(temp_voorschrift, "‘" + (temp_teller++).ToString() + "’");
									temp_waarden.Add(paramlist[i]);
								}
								#endregion

								#region Uitrekenenen
								paramlist.Add(BerekenFuncties(temp_voorschrift, temp_waarden, store, hoek));
								Regex r = new Regex("\\b" + t.Split(';')[0] + "\\b");
								functie_voorschrift = r.Replace(functie_voorschrift, "‘" + (teller++) + "’");
								#endregion
							}
							#endregion

							#region Parameters Vervangen
							for(int i = 0; i < functie_parameters.Length; i++)
							{
								Regex rgx2 = new Regex("\\b" + functie_parameters[i].Split(';')[0] + "\\b");
								functie_voorschrift = rgx2.Replace(functie_voorschrift, "‘" + i.ToString() + "’");
							}
							#endregion

							#region Uitrekenen
							getallen.Add(BerekenFuncties(functie_voorschrift, paramlist, store, hoek));
							#endregion
							break;
					}
					bewerking = bewerking.Replace(src, "‘" + (getallen.Count - 1).ToString() + "’");
				}
				return BerekenHaakjes(bewerking, getallen, store);
			}
		}
		public double BerekenHaakjes(string bewerking, List<double> getallen, bool store)
		{
			int haakjestekort = bewerking.Count(T => T == '(') - bewerking.Count(T => T == ')');
			if(haakjestekort < 0)
			{
				MessageBox.Show("Fout 1");
				return 0;
			}
			else
			{
				for(int i = 0; i < haakjestekort; i++)
					bewerking += ')';
				Stack<int> HaakjesOpen = new Stack<int>();
				for(int i = 0; i < bewerking.Length; i++)
				{
					switch(bewerking[i])
					{
						case '(':
							HaakjesOpen.Push(i);
							break;
						case ')':
							int t = HaakjesOpen.Pop();
							string gewonebewerking = bewerking.Substring(t + 1, i - 1 - t);
							double resultaat = BerekenGewoon(gewonebewerking, getallen, store);
							bewerking = bewerking.Replace("(" + gewonebewerking + ")", "‘" + (getallen.Count).ToString() + "’");
							i -= gewonebewerking.Length - getallen.Count.ToString().Length;
							getallen.Add(resultaat);
							break;
					}
				}
				return BerekenGewoon(bewerking, getallen, store);
			}
		}
		public double BerekenGewoon(string bewerking, List<double> getallen, bool store)
		{
			// faculteit
			Regex rgx = new Regex(@"‘[0-9]*’\!(‘[0-9]*’)*");
			Match m = rgx.Match(bewerking);
			while(m.Success)
			{
				string[] it = m.Value.Split(new char[] { '!' }, StringSplitOptions.RemoveEmptyEntries);
				int index1 = Convert.ToInt16(it[0].Substring(1, it[0].Length - 2));
				int index2 = it.Length < 2 ? -1 : Convert.ToInt16(it[1].Substring(1, it[1].Length - 2));

				double resultaat = faculteit(getallen[index1]);
				if(index2 != -1) resultaat *= getallen[index2];
				getallen.Add(resultaat);
				bewerking = bewerking.Replace(m.Value, "‘" + (getallen.Count - 1).ToString() + "’");

				m = rgx.Match(bewerking);
			}

			// machten wortels
			rgx = new Regex(@"‘[0-9]*’(\^|√)‘[0-9]*’");
			m = rgx.Match(bewerking);
			while(m.Success)
			{
				Regex operatie = new Regex(@"(\^|√)");
				string[] items = operatie.Split(m.Value);

				int index1 = Convert.ToInt16(items[0].Substring(1, items[0].Length - 2));
				int index2 = Convert.ToInt16(items[2].Substring(1, items[2].Length - 2));
				string op = items[1];

				double resultaat;
				switch(op)
				{
					case "^":
						resultaat = Math.Pow(getallen[index1], getallen[index2]);
						break;
					case "√":
						resultaat = Math.Pow(getallen[index2], 1 / getallen[index1]);
						break;
					default:
						resultaat = 0;
						break;
				}
				getallen.Add(resultaat);
				bewerking = bewerking.Replace(m.Value, "‘" + (getallen.Count - 1).ToString() + "’");

				m = rgx.Match(bewerking);
			}

			// producten quotienten
			rgx = new Regex(@"‘[0-9]*’(\*|\/|\\|%)‘[0-9]*’");
			m = rgx.Match(bewerking);
			while(m.Success)
			{
				Regex operatie = new Regex(@"(\*|\/|\\|%)");
				string[] items = operatie.Split(m.Value);

				int index1 = Convert.ToInt16(items[0].Substring(1, items[0].Length - 2));
				int index2 = Convert.ToInt16(items[2].Substring(1, items[2].Length - 2));
				string op = items[1];

				double resultaat;
				switch(op)
				{
					case "*":
						resultaat = getallen[index1] * getallen[index2];
						break;
					case "/":
						resultaat = getallen[index1] / getallen[index2];
						break;
					case "\\":
						resultaat = (getallen[index1] - getallen[index1] % getallen[index2]) / getallen[index2];
						break;
					case "%":
						resultaat = modulo(getallen[index1], getallen[index2]);
						break;
					default:
						resultaat = 0;
						break;
				}
				getallen.Add(resultaat);
				bewerking = bewerking.Replace(m.Value, "‘" + (getallen.Count - 1).ToString() + "’");

				m = rgx.Match(bewerking);
			}

			// sommen verschillen
			rgx = new Regex(@"‘[0-9]*’(\+|\–)‘[0-9]*’");
			m = rgx.Match(bewerking);
			while(m.Success)
			{
				Regex operatie = new Regex(@"(\+|\–)");
				string[] items = operatie.Split(m.Value);

				int index1 = Convert.ToInt16(items[0].Substring(1, items[0].Length - 2));
				int index2 = Convert.ToInt16(items[2].Substring(1, items[2].Length - 2));
				string op = items[1];

				double resultaat;
				switch(op)
				{
					case "+":
						resultaat = getallen[index1] + getallen[index2];
						break;
					case "–":
						resultaat = getallen[index1] - getallen[index2];
						break;
					default:
						resultaat = 0;
						break;
				}
				getallen.Add(resultaat);
				bewerking = bewerking.Replace(m.Value, "‘" + (getallen.Count - 1).ToString() + "’");

				m = rgx.Match(bewerking);
			}

			// Vergelijkingen
			rgx = new Regex(@"‘[0-9]*’(<|≤|=|≠|≥|>)‘[0-9]*’");
			m = rgx.Match(bewerking);
			while(m.Success)
			{
				Regex operatie = new Regex(@"(<|≤|=|≠|≥|>)");
				string[] items = operatie.Split(m.Value);

				int index1 = Convert.ToInt16(items[0].Substring(1, items[0].Length - 2));
				int index2 = Convert.ToInt16(items[2].Substring(1, items[2].Length - 2));
				string op = items[1];

				double resultaat;
				switch(op)
				{
					case "<":
						resultaat = getallen[index1] < getallen[index2] ? 1 : 0;
						break;
					case "≤":
						resultaat = getallen[index1] <= getallen[index2] ? 1 : 0;
						break;
					case "=":
						resultaat = getallen[index1] == getallen[index2] ? 1 : 0;
						break;
					case "≠":
						resultaat = getallen[index1] != getallen[index2] ? 1 : 0;
						break;
					case "≥":
						resultaat = getallen[index1] >= getallen[index2] ? 1 : 0;
						break;
					case ">":
						resultaat = getallen[index1] > getallen[index2] ? 1 : 0;
						break;
					default:
						resultaat = 0;
						break;
				}
				getallen.Add(resultaat);
				bewerking = bewerking.Replace(m.Value, "‘" + (getallen.Count - 1).ToString() + "’");

				m = rgx.Match(bewerking);
			}



			rgx = new Regex(@"‘[0-9]*’(\&)‘[0-9]*’");
			m = rgx.Match(bewerking);
			while(m.Success)
			{
				Regex operatie = new Regex(@"\&");
				string[] items = operatie.Split(m.Value);

				int index1 = Convert.ToInt16(items[0].Substring(1, items[0].Length - 2));
				int index2 = Convert.ToInt16(items[1].Substring(1, items[1].Length - 2));

				double resultaat = Convert.ToDouble((int)getallen[index1] & (int)getallen[index2]);

				getallen.Add(resultaat);
				bewerking = bewerking.Replace(m.Value, "‘" + (getallen.Count - 1).ToString() + "’");

				m = rgx.Match(bewerking);
			}

			rgx = new Regex(@"‘[0-9]*’(\||⊖|⊕)‘[0-9]*’");
			m = rgx.Match(bewerking);
			while(m.Success)
			{
				Regex operatie = new Regex(@"(\||⊖|⊕)");
				string[] items = operatie.Split(m.Value);

				int index1 = Convert.ToInt16(items[0].Substring(1, items[0].Length - 2));
				int index2 = Convert.ToInt16(items[2].Substring(1, items[2].Length - 2));
				string op = items[1];

				double resultaat;
				switch(op)
				{
					case "|":
						resultaat = Convert.ToDouble((int)getallen[index1] | (int)getallen[index2]);
						break;
					case "⊕":
						resultaat = Convert.ToDouble((int)getallen[index1] ^ (int)getallen[index2]);
						break;
					case "⊖":
						resultaat = Convert.ToDouble(~((int)getallen[index1] ^ (int)getallen[index2]));
						break;
					default:
						resultaat = 0;
						break;
				}


				getallen.Add(resultaat);
				bewerking = bewerking.Replace(m.Value, "‘" + (getallen.Count - 1).ToString() + "’");

				m = rgx.Match(bewerking);
			}

			// store →
			// machten wortels
			rgx = new Regex(@"‘[0-9]*’→‘[0-9]*’");
			m = rgx.Match(bewerking);
			while(m.Success)
			{
				Regex operatie = new Regex("→");
				string[] items = operatie.Split(m.Value);

				int index1 = Convert.ToInt16(items[0].Substring(1, items[0].Length - 2));
				int index2 = Convert.ToInt16(items[1].Substring(1, items[1].Length - 2));

				if(store)
				{
					if(Geheugen.ContainsKey(getallen[index2]))
						Geheugen[getallen[index2]] = getallen[index1];
					else
						Geheugen.Add(getallen[index2], getallen[index1]);
				}

				bewerking = bewerking.Replace(m.Value, "‘" + index1.ToString() + "’");

				m = rgx.Match(bewerking);
			}

			return getallen[Convert.ToInt16(bewerking.Substring(1, bewerking.Length - 2))];
		}

		private double modulo(double v1, double v2)
		{
			return v1 - Math.Floor(v1 / v2) * v2;
		}

		public double faculteit(double getal)
		{
			long getal2 = Convert.ToInt64(getal);
			if(getal2 <= 0) return 0;
			long result = 1;
			for(long i = 2; i <= getal2; i++)
				result *= i;
			return result;
		}

		int talstelsel = 10;
		private void TalstelselVeranderd(object sender, EventArgs e)
		{
			if(!((RadioButton)sender).Checked) return;
			int oud = talstelsel;
			talstelsel = GetTalstelsel();

			string format;
			double[] getallen;
			ZoekGetallen(txtBewerking.Text, oud, 0, out format, out getallen);

			IEnumerable<string> it = getallen.Select(T => (T == Math.E ? "e" : (T == Math.PI ? "pi" : VanDecimaal(T, talstelsel))));
			txtBewerking.Text = string.Format(format.Replace("{", "{{").Replace("}", "}}").Replace("‘", "{").Replace("’", "}"), it.ToArray());
			if(txtUitkomst.Text != "")
				button1_Click(sender, e);

			btn2.Enabled = talstelsel > 2;
			btn3.Enabled = talstelsel > 2;
			btn4.Enabled = talstelsel > 2;
			btn5.Enabled = talstelsel > 2;
			btn6.Enabled = talstelsel > 2;
			btn7.Enabled = talstelsel > 2;
			btn8.Enabled = talstelsel > 8;
			btn9.Enabled = talstelsel > 8;
			btnA.Enabled = talstelsel > 10;
			btnB.Enabled = talstelsel > 10;
			btnC.Enabled = talstelsel > 10;
			btnD.Enabled = talstelsel > 10;
			btnE.Enabled = talstelsel > 10;
			btnF.Enabled = talstelsel > 10;
		}

		private void HoekMaatVeranderd(object sender, EventArgs e)
		{

		}

		private void CijferInvoeren(object sender, EventArgs e)
		{
			string cijfer = ((Control)sender).Text.TrimStart('&');

			Regex rgx = new Regex("(([0-9A-Z]+([" + komma + "][0-9A-Z]*)*)|(e)|(pi))$");
			Match m = rgx.Match(txtBewerking.Text);
			if(m.Success)
			{
				if(m.Value == "0")
				{
					txtBewerking.Text = txtBewerking.Text.Delete(1) + cijfer;
				}
				else if((m.Value == "pi") | (m.Value == "e"))
				{
					txtBewerking.Text += "*" + cijfer;
				}
				else
				{
					txtBewerking.Text += cijfer;
				}
			}
			else if(txtBewerking.Text.EndsWith(")"))
			{
				txtBewerking.Text += "*" + cijfer;
			}
			else
			{
				txtBewerking.Text += cijfer;
			}
		}
		private void KommaInvoeren(object sender, EventArgs e)
		{
			Regex rgx = new Regex("([0-9A-Z]+([" + komma + "][0-9A-Z]*)*)$");
			Match m = rgx.Match(txtBewerking.Text);
			if(m.Success)
			{
				if(m.Value.Contains(komma))
				{
					SystemSounds.Beep.Play();
				}
				else
				{
					txtBewerking.Text += komma;
				}
			}
			else if(txtBewerking.Text.EndsWith(")"))
			{
				txtBewerking.Text += "*0" + komma;
			}
			else if(txtBewerking.Text.EndsWith("("))
			{
				txtBewerking.Text += "0" + komma;
			}
			else if(txtBewerking.Text == "")
			{
				txtBewerking.Text += "0" + komma;
			}
			else if(txtBewerking.Text.EndsWith("-"))
			{
				txtBewerking.Text += "0" + komma;
			}
			else
			{
				Regex rgx2 = new Regex("([a-z]+)$");
				if(rgx2.IsMatch(txtBewerking.Text))
					txtBewerking.Text += "*0" + komma;
				else
					txtBewerking.Text += "0" + komma;
			}
		}
		private void NegatiefMaken(object sender, EventArgs e)
		{
			Regex rgx = new Regex("(\\-)*([0-9A-Z]+([" + komma + "][0-9A-Z]*)*)$");
			Match m = rgx.Match(txtBewerking.Text);
			if(m.Success)
			{
				if(m.Value.StartsWith("-"))
				{
					txtBewerking.Text = txtBewerking.Text.Remove(m.Index, 1);
				}
				else
				{
					txtBewerking.Text = txtBewerking.Text.Insert(m.Index, "-");
				}
			}
			else
			{
				if(txtBewerking.Text.EndsWith(")"))
					txtBewerking.Text += "*-";
				else if(txtBewerking.Text.EndsWith("-"))
					txtBewerking.Text = txtBewerking.Text.Remove(txtBewerking.Text.Length - 1);
				else
					txtBewerking.Text += "-";
			}
		}
		private void TekenInvoeren(object sender, EventArgs e)
		{
			string teken = ((Control)sender).Tag.ToString();
			if(txtBewerking.Text == "")
			{
				if(teken == "√")
					txtBewerking.Text = "2√";
				else
					SystemSounds.Beep.Play();
			}
			else
			{
				string tekens = "+–*/\\%^√→&|⊕⊖<≤=≠≥>";
				if(tekens.Contains(txtBewerking.Text.Last()))
					txtBewerking.Text = txtBewerking.Text.Remove(txtBewerking.Text.Length - 1);
				txtBewerking.Text += teken;
			}
		}

		private void FunctieInvoeren(object sender, EventArgs e)
		{
			string naam = "";
			try
			{
				naam = ((Control)sender).Text;
			}
			catch(Exception)
			{
				naam = ((ToolStripItem)sender).Text;
			}
			Regex rgx = new Regex("([\\)]|[0-9A-Z]|[" + komma + "])$"); //eindigt op getal, ")" of ","
			Match m = rgx.Match(txtBewerking.Text);
			if(m.Success)
			{
				txtBewerking.Text += "*" + naam + "(";
			}
			else
			{
				txtBewerking.Text += naam + "(";
			}
		}
		private void GonFunctieInvoeren(object sender, EventArgs e)
		{
			string naam = "";
			if(btnBg.Checked) naam += "bg";
			naam += ((Control)sender).Text;
			if(btnHyp.Checked) naam += "h";
			else
			{
				if(rbnGraden.Checked) naam += "d";
				else if(rbnGon.Checked) naam += "g";
			}

			Regex rgx = new Regex("([\\)]|[0-9A-Z]|[" + komma + "])$"); //eindigt op getal, ")" of ","
			Match m = rgx.Match(txtBewerking.Text);
			if(m.Success)
			{
				txtBewerking.Text += "*" + naam + "(";
			}
			else
			{
				txtBewerking.Text += naam + "(";
			}
			btnBg.Checked = false;
			btnHyp.Checked = false;
		}

		private void HaakjeOpen(object sender, EventArgs e)
		{
			Regex rgx = new Regex("([\\)]|[0-9A-Z]|[" + komma + "])$"); //eindigt op getal, ")" of ","
			Match m = rgx.Match(txtBewerking.Text);
			if(m.Success)
			{
				txtBewerking.Text += "*(";
			}
			else
			{
				txtBewerking.Text += "(";
			}
		}

		private void HaakjeDicht(object sender, EventArgs e)
		{
			string tekens = "+–*/\\%^√→";
			int over = txtBewerking.Text.Count(T => T == '(') - txtBewerking.Text.Count(T => T == ')');
			if(tekens.Contains(txtBewerking.Text.LastOrDefault()))
			{
				txtBewerking.Text = (over == 0 ? "(" : "") + txtBewerking.Text.Delete(1) + ")";
			}
			else
			{
				txtBewerking.Text = (over == 0 ? "(" : "") + txtBewerking.Text + ")";
			}
		}

		private void Const_invoeren(object sender, EventArgs e)
		{
			string naam = ((Control)sender).Tag.ToString();

			Regex rgx = new Regex("(([0-9A-Z]+([" + komma + "][0-9A-Z]*)*)|(e)|(pi))$");
			Match m = rgx.Match(txtBewerking.Text);
			if(m.Success)
			{
				if(m.Value == "0")
				{
					txtBewerking.Text = txtBewerking.Text.Delete(1) + naam;
				}
				else
				{
					txtBewerking.Text += "*" + naam;
				}
			}
			else if(txtBewerking.Text.EndsWith(")"))
			{
				txtBewerking.Text += "*" + naam;
			}
			else
			{
				txtBewerking.Text += naam;
			}
		}

		private void btnAutoUitkomst_CheckedChanged(object sender, EventArgs e)
		{
			btnUitkomst.Enabled = !btnAutoUitkomst.Checked;
			if(btnAutoUitkomst.Checked) button1_Click(this, EventArgs.Empty);
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			txtBewerking.Clear();
			txtUitkomst.Clear();
		}

		private void btnReturn_Click(object sender, EventArgs e)
		{
			if((txtUitkomst.Text != "") & !btnAutoUitkomst.Checked)
			{
				txtUitkomst.Text = "";
			}
			else
			{
				Regex rgx = new Regex("([a-z]+\\()$"); //eindigt op functie
				Match m = rgx.Match(txtBewerking.Text);
				if(m.Success)
				{
					txtBewerking.Text = txtBewerking.Text.Delete(m.Length);
				}
				else
				{
					Regex rgx2 = new Regex("([a-z]+)$");
					Match m2 = rgx2.Match(txtBewerking.Text);
					if(m2.Success)
					{
						txtBewerking.Text = txtBewerking.Text.Delete(m2.Length);
					}
					else
					{
						txtBewerking.Text = txtBewerking.Text.Delete(1);
					}
				}
			}
		}

		private void txtBewerking_TextChanged(object sender, EventArgs e)
		{
			int w1 = TextRenderer.MeasureText(txtBewerking.Text, txtBewerking.Font).Width;
			int w2 = TextRenderer.MeasureText(txtUitkomst.Text, txtUitkomst.Font).Width;
			panel4.Width = Math.Max(w1, w2) + 10;
			panel5.AutoScrollPosition = new Point(Math.Max(0, panel4.Width - panel5.Width), 0);

			if(btnAutoUitkomst.Checked)
			{
				try
				{
					double[] getallen;
					string format;
					ZoekGetallen(txtBewerking.Text, GetTalstelsel(), 0, out format, out getallen);

					enHoekmaat hoek;
					if(rbnGraden.Checked) hoek = enHoekmaat.Graden;
					else if(rbnGon.Checked) hoek = enHoekmaat.Gradienten;
					else hoek = enHoekmaat.Radialen;

					UITKOMST = BerekenFuncties(format, getallen.ToList(), false, hoek);
					txtUitkomst.Text = VanDecimaal(UITKOMST, GetTalstelsel());
				}
				catch(Exception)
				{
				}
			}
			try
			{
				Regex rgx = new Regex(@"[a-z]+\(");
				Match[] matchen = rgx.Matches(txtBewerking.Text).Reverse();
				foreach(Match m in matchen)
				{
					if(txtBewerking.Text.Substring(m.Index).Count(T => T == '(') > txtBewerking.Text.Substring(m.Index).Count(T => T == ')'))
					{
						int lasttoken = m.Index + m.Length; //laatste (
						int paramnr = 1;
						int level = 0;
						frmInfoLabel.FunctieNaam = m.Value.Delete(1);

						for(int i = lasttoken; i < txtBewerking.Text.Length; i++)
						{
							switch(txtBewerking.Text[i])
							{
								case '(':
									level++;
									break;
								case ')':
									level--;
									break;
								case ';':
									if(level == 0)
									{
										++paramnr;
									}
									break;
							}
						}

						switch(m.Value.Delete(1))
						{
							case "sin":
								frmInfoLabel.FunctieBeschrijving = "Berekent het tweede coördinaatgetal van de projectie van de hoek op de eenheidscirkel";
								frmInfoLabel.ParamNaam = "hoek";
								frmInfoLabel.ParamBeschrijving = "Hoek waarvan de sinus moet berekend worden";
								break;
							case "cos":
								frmInfoLabel.FunctieBeschrijving = "Berekent het eerste coördinaatgetal van de projectie van de hoek op de eenheidscirkel";
								frmInfoLabel.ParamNaam = "hoek";
								frmInfoLabel.ParamBeschrijving = "Hoek waarvan de cosinus moet berekend worden";
								break;
							case "tan":
								frmInfoLabel.FunctieBeschrijving = "Berekent het tweede coördinaatgetal van de projectie van de hoek op de rechte \"x=1\"";
								frmInfoLabel.ParamNaam = "hoek";
								frmInfoLabel.ParamBeschrijving = "Hoek waarvan de tangens moet berekend worden";
								break;
							case "csc":
								frmInfoLabel.FunctieBeschrijving = "Berekent de inverse waarde van de sinus van de opgegeven hoek";
								frmInfoLabel.ParamNaam = "hoek";
								frmInfoLabel.ParamBeschrijving = "Hoek waarvan de cosecans moet berekend worden";
								break;
							case "sec":
								frmInfoLabel.FunctieBeschrijving = "Berekent de inverse waarde van de cosinus van de opgegeven hoek";
								frmInfoLabel.ParamNaam = "hoek";
								frmInfoLabel.ParamBeschrijving = "Hoek waarvan de secans moet berekend worden";
								break;
							case "cot":
								frmInfoLabel.FunctieBeschrijving = "Berekent de inverse waarde van de tangens van de opgegeven hoek";
								frmInfoLabel.ParamNaam = "hoek";
								frmInfoLabel.ParamBeschrijving = "Hoek waarvan de cotangens moet berekend worden";
								break;
							case "bgsin":
								frmInfoLabel.FunctieBeschrijving = "Berekent de hoek waarvoor de sinus gelijk is aan de opgegeven waarde";
								frmInfoLabel.ParamNaam = "sinus";
								frmInfoLabel.ParamBeschrijving = "Waarde waarvan de boogsinus moet berekend worden";
								break;
							case "bgcos":
								frmInfoLabel.FunctieBeschrijving = "Berekent de hoek waarvoor de cosinus gelijk is aan de opgegeven waarde";
								frmInfoLabel.ParamNaam = "cosinus";
								frmInfoLabel.ParamBeschrijving = "Waarde waarvan de boogcosinus moet berekend worden";
								break;
							case "bgtan":
								frmInfoLabel.FunctieBeschrijving = "Berekent de hoek waarvoor de tangens gelijk is aan de opgegeven waarde";
								frmInfoLabel.ParamNaam = "tangens";
								frmInfoLabel.ParamBeschrijving = "Waarde waarvan de boogtangens moet berekend worden";
								break;
							case "bgcsc":
								frmInfoLabel.FunctieBeschrijving = "Berekent de hoek waarvoor de cosecans gelijk is aan de opgegeven waarde";
								frmInfoLabel.ParamNaam = "cosecans";
								frmInfoLabel.ParamBeschrijving = "Waarde waarvan de boogcosecans moet berekend worden";
								break;
							case "bgsec":
								frmInfoLabel.FunctieBeschrijving = "Berekent de hoek waarvoor de secans gelijk is aan de opgegeven waarde";
								frmInfoLabel.ParamNaam = "secans";
								frmInfoLabel.ParamBeschrijving = "Waarde waarvan de boogsecans moet berekend worden";
								break;
							case "bgcot":
								frmInfoLabel.FunctieBeschrijving = "Berekent de hoek waarvoor de cotangens gelijk is aan de opgegeven waarde";
								frmInfoLabel.ParamNaam = "cotangens";
								frmInfoLabel.ParamBeschrijving = "Waarde waarvan de boogcotangens moet berekend worden";
								break;
							case "sinh":
							case "cosh":
							case "tanh":
							case "csch":
							case "sech":
							case "coth":
							case "bgsinh":
							case "bgcosh":
							case "bgtanh":
							case "bgcsch":
							case "bgsech":
							case "bgcoth":
								frmInfoLabel.FunctieBeschrijving = "";
								frmInfoLabel.ParamNaam = "";
								frmInfoLabel.ParamBeschrijving = "";
								break;
							case "ln":
								frmInfoLabel.FunctieBeschrijving = "Berekent de Neperiaanse logaritme van de opgegeven waarde (e ^ x = input)";
								frmInfoLabel.ParamNaam = "input";
								frmInfoLabel.ParamBeschrijving = "Te bekomen getal";
								break;
							case "log":
								if(paramnr == 1)
								{
									frmInfoLabel.FunctieBeschrijving = "Berekent de Briggse logaritme van de opgegeven waarde (10 ^ x = input)";
									frmInfoLabel.ParamNaam = "input";
									frmInfoLabel.ParamBeschrijving = "Te bekomen getal";
								}
								else
								{
									frmInfoLabel.FunctieBeschrijving = "Berekent de logaritme van de opgegeven waarde (a ^ x = input)";
									frmInfoLabel.ParamNaam = "a";
									frmInfoLabel.ParamBeschrijving = "Grondtal";
								}
								break;
							case "exp":
								frmInfoLabel.FunctieBeschrijving = "Berekent e ^ x";
								frmInfoLabel.ParamNaam = "x";
								frmInfoLabel.ParamBeschrijving = "exponent";
								break;
							case "rcl":
								frmInfoLabel.FunctieBeschrijving = "Haalt een waarde op uit het geheugen";
								frmInfoLabel.ParamNaam = "adres";
								frmInfoLabel.ParamBeschrijving = "Adres";
								break;
							default:
								string bestand = mapnaam_func + m.Value.Delete(1) + ".func";
								FileStream fs = new FileStream(bestand, FileMode.Open);

								Rijndael rijAlg = Rijndael.Create();
								rijAlg.Key = key;
								rijAlg.IV = IV;
								ICryptoTransform decryptor = rijAlg.CreateDecryptor(key, IV);

								CryptoStream cs = new CryptoStream(fs, decryptor, CryptoStreamMode.Read);
								StreamReader reader = new StreamReader(cs);
								string tekst = reader.ReadToEnd();
								reader.Close();

								string[] blokken = tekst.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None);
								string[] paramlijnen = blokken[1].Split(new string[] { "\r\n" }, StringSplitOptions.None);
								string[] it = paramlijnen[paramnr - 1].Split(';');

								frmInfoLabel.FunctieBeschrijving = blokken[0].Split(new string[] { "\r\n" }, StringSplitOptions.None)[1];
								frmInfoLabel.ParamNaam = it[0];
								frmInfoLabel.ParamBeschrijving = it[1];
								break;
						}
						frmInfoLabel.Show();
						frmInfoLabel.DesktopLocation = txtBewerking.PointToScreen(new Point(0, txtBewerking.Height));
						return;
					}
				}
				frmInfoLabel.Visible = false;
			}
			catch(Exception)
			{
			}
		}

		private InfoForm frmInfoLabel = new InfoForm();

		private void txtUitkomst_TextChanged(object sender, EventArgs e)
		{
			btnDMS.Enabled = (txtUitkomst.Text != "");
			btnFrac.Enabled = (txtUitkomst.Text != "");
			int w1 = TextRenderer.MeasureText(txtBewerking.Text, txtBewerking.Font).Width;
			int w2 = TextRenderer.MeasureText(txtUitkomst.Text, txtUitkomst.Font).Width;
			panel4.Width = Math.Max(w1, w2) + 15;
			panel4.AutoScrollPosition = new Point(Math.Max(0, panel4.Width - panel5.Width), 0);

		}

		private void btnEditFunc_Click(object sender, EventArgs e)
		{
			frmFuncties func = new frmFuncties();
			func.ShowDialog();
		}

		protected override bool IsInputKey(Keys keyData)
		{
			if(keyData == Keys.Enter) return false;
			return base.IsInputKey(keyData);
		}

		private void Hoofdscherm_KeyDown(object sender, KeyEventArgs e)
		{
			switch(e.KeyCode)
			{
				case Keys.Back:
					btnReturn_Click(sender, e);
					break;
				case Keys.Delete:
					btnClear_Click(sender, e);
					break;
				case Keys.Oem6:
					TekenInvoeren(btnMacht, EventArgs.Empty);
					break;
				case Keys.Enter:
					button1_Click(sender, e);
					break;
			}
		}

		string mapnaam_func = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Rekenmachine\Functies\";
		private void btnFunc_Click(object sender, EventArgs e)
		{
			cmsFuncties.Items.Clear();
			foreach(string bestand in Directory.GetFiles(mapnaam_func))
			{
				ToolStripMenuItem tmi = new ToolStripMenuItem();
				tmi.Text = Path.GetFileNameWithoutExtension(bestand);
				tmi.Click += FunctieInvoeren;
				cmsFuncties.Items.Add(tmi);
			}
			cmsFuncties.Show(Control.MousePosition);
		}

		private void Hoofdscherm_LocationChanged(object sender, EventArgs e)
		{
			frmInfoLabel.DesktopLocation = txtBewerking.PointToScreen(new Point(0, txtBewerking.Height));
		}

		private void rbnStijlChanged(object sender, EventArgs e)
		{
			FlatStyle fl;
			if(rbnStijlFlat.Checked)
				fl = FlatStyle.Flat;
			else if(rbnStijlPopup.Checked)
				fl = FlatStyle.Popup;
			else if(rbnStijlSystem.Checked)
				fl = FlatStyle.System;
			else
				fl = FlatStyle.Standard;

			Properties.Settings.Default.Stijl = (int)fl;
			Properties.Settings.Default.Save();
			SetStyleToChildren(fl, this);
		}

		void SetStyleToChildren(FlatStyle stijl, Control parent)
		{
			foreach(Control ctl in parent.Controls)
			{
				if(ctl.GetType() == typeof(Button))
					((Button)ctl).FlatStyle = stijl;
				else if(ctl.GetType() == typeof(CheckBox))
					((CheckBox)ctl).FlatStyle = stijl;
				else if(ctl.GetType() == typeof(RadioButton))
					((RadioButton)ctl).FlatStyle = stijl;
				else if(ctl.GetType() == typeof(Panel))
					SetStyleToChildren(stijl, ctl);
			}
		}

		private void btnDMS_Click(object sender, EventArgs e)
		{
			int t = GetTalstelsel();
			double waarde = UITKOMST;

			bool neg = waarde < 0;
			waarde = Math.Abs(waarde);

			int d = (int)(waarde - waarde % 1);
			waarde = (waarde % 1) * 60;
			int m = (int)(waarde - waarde % 1);
			double s = (waarde % 1) * 60;

			txtUitkomst.Text = (neg ? "-" : "") + string.Format("{0}°{1}'{2}\"", VanDecimaal(d, t), VanDecimaal(m, t), VanDecimaal(s, t));

			btnDMS.Enabled = false;
			btnFrac.Enabled = false;
		}

		private void btnFrac_Click(object sender, EventArgs e)
		{
			int t = GetTalstelsel();

			long[] breuk = Frac(UITKOMST);
			txtUitkomst.Text = string.Format("{0} / {1}", VanDecimaal(breuk[0], t), VanDecimaal(breuk[1], t));

			btnDMS.Enabled = false;
			btnFrac.Enabled = false;
		}
		public long[] Frac(double x, double error = double.Epsilon)
		{
			int n = (int)Math.Floor(x);
			x -= n;
			if(x < error)
			{
				return new long[] { n, 1 };
			}
			else if(1 - error < x)
			{
				return new long[] { n + 1, 1 };
			}

			// The lower fraction is 0/1
			long lower_teller = 0;
			long lower_noemer = 1;

			// The upper fraction is 1/1
			long upper_teller = 1;
			long upper_noemer = 1;

			while(true)
			{
				// The middle fraction is (lower_teller + upper_teller) / (lower_noemer + upper_telleroemer)
				long middle_teller = lower_teller + upper_teller;
				long middle_noemer = lower_noemer + upper_noemer;

				// If x + error < middle
				//if((x + error) * middle_noemer < middle_teller)
				if(x * middle_noemer < middle_teller)
				{
					// middle is our new upper
					upper_teller = middle_teller;
					upper_noemer = middle_noemer;
				}
				// Else If middle < x - error
				//else if((x - error) * middle_noemer > middle_teller)
                else if(x * middle_noemer > middle_teller)
				{
					// middle is our new lower
					lower_teller = middle_teller;
					lower_noemer = middle_noemer;
				}
				else
				{
					// middle is our best fraction
					return new long[] { n * middle_noemer + middle_teller, middle_noemer };
				}
			}
		}
	}
}
