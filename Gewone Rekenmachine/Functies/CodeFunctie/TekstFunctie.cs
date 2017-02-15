using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Gewone_Rekenmachine
{
    public class TekstFunctie : Functie
    {
        public TekstFunctie()
            : base(enFunctie_type.tekst)
        {
        }

        #region Naam
        private string naam;
        public string Naam
        {
            get { return naam; }
            set { naam = value; }
        }
        #endregion
        #region Parameters
        private List<Variabele> parameters = new List<Variabele>();
        public List<Variabele> Parameters
        {
            get { return parameters; }
        }
        #endregion
        #region Body
        private Block body = new Block();
        public Block Body
        {
            get { return body; }
            set { body = value; }
        }

        #endregion
        private string source = "";
        public void Parse(string tekst)
        {
            source = tekst;
            string header = tekst.Split('{')[0].Replace("\r\n", "");

            if(!header.StartsWith("function "))
                throw new InvalidHeaderException("Functie moet starten met \"function\"");

            if (!header.Contains("("))
                throw new InvalidHeaderException("Missing (");

            Regex rgx = new Regex(@"(?<=function\s+)([a-zA-Z_]+)(?=\s*\()");
            Match functie_m = rgx.Match(header);
            if(!functie_m.Success)
                throw new InvalidHeaderException("Functienaam mag slechts 1 woord zijn");

            naam = functie_m.Value;

            Regex rgx2 = new Regex(@"\(");
            Match start_m = rgx2.Match(header, functie_m.Index + functie_m.Length);
            int start = start_m.Index;

            rgx2 = new Regex(@"\)");
            int einde = rgx2.Match(header).Index;

            parameters = tekst.Substring(start + 1, einde - start - 1).Split(',').Select(T => new Variabele(T)).ToList();

            int bodyStart = tekst.IndexOf('{') + 1;
            int level = 0;
            Regex rgx3 = new Regex("{|}");
            Match m = rgx3.Match(tekst, bodyStart);
            int bodyEnd = 0;
            while (m.Success)
            {
                switch(m.Value)
                {
                    case "{":
                        level++;
                        break;
                    case "}":
                        if(--level == -1)
                        {
                            bodyEnd = m.Index - 1;
                            goto do_parse;
                        }
                        break;
                }
                m = m.NextMatch();
            }

do_parse:   body.Parse(tekst.Substring(bodyStart, bodyEnd - bodyStart + 1));

        }
        public override string ToString()
        {
            return source;
        }
    }
}

/*
Regex rgx = new Regex(@"(?<=function )([a-z]+)(?=\s*\()");
MatchCollection matches = rgx.Matches(tekst);
if (matches.Count == 0)
    return "Naamloos";
else return matches[0].Value;
*/
