using System.Diagnostics.Metrics;

namespace PowerAccent.Core
{
    public enum Language
    {
        FR,
        PL,
        SP,
        TK,
    }

    internal static class Languages
    {
        public static char[] GetDefaultLetterKey(LetterKey letter, Language lang)
        {
            switch (lang)
            {
                case Language.FR: return GetDefaultLetterKeyFR(letter);
                case Language.SP: return GetDefaultLetterKeySP(letter);
                case Language.TK: return GetDefaultLetterKeyTK(letter);
                case Language.PL: return GetDefaultLetterKeyPL(letter);
            }

            throw new ArgumentException("The language {0} is not know in this context", lang.ToString());
        }

        public static string GetFlag(Language lang)
        {
            return string.Concat(lang.ToString().ToUpper().Select(x => char.ConvertFromUtf32(x + 0x1F1A5)));
        }

        // French
        private static char[] GetDefaultLetterKeyFR(LetterKey letter)
        {
            switch (letter)
            {
                case LetterKey.A:
                    return new char[] { 'à', 'â', 'á', 'ä', 'ã' };
                case LetterKey.C:
                    return new char[] { 'ç' };
                case LetterKey.E:
                    return new char[] { 'é', 'è', 'ê', 'ë', '€' };
                case LetterKey.I:
                    return new char[] { 'î', 'ï', 'í', 'ì' };
                case LetterKey.O:
                    return new char[] { 'ô', 'ö', 'ó', 'ò', 'õ' };
                case LetterKey.U:
                    return new char[] { 'û', 'ù', 'ü', 'ú' };
                case LetterKey.Y:
                    return new char[] { 'ÿ', 'ý' };
            }

            return Array.Empty<char>();
        }

        // Spain
        private static char[] GetDefaultLetterKeySP(LetterKey letter)
        {
            switch (letter)
            {
                case LetterKey.A:
                    return new char[] { 'á' };
                case LetterKey.E:
                    return new char[] { 'é', '€' };
                case LetterKey.I:
                    return new char[] { 'í' };
                case LetterKey.N:
                    return new char[] { 'ñ' };
                case LetterKey.O:
                    return new char[] { 'ó' };
                case LetterKey.U:
                    return new char[] { 'ü', 'ú' };
                case LetterKey._:
                    return new char[] { '¿', '?' };
            }

            return Array.Empty<char>();
        }

        // Turkish
        private static char[] GetDefaultLetterKeyTK(LetterKey letter)
        {
            switch (letter)
            {
                case LetterKey.A:
                    return new char[] { 'â', 'ä', 'æ' };
                case LetterKey.C:
                    return new char[] { 'ç' };
                case LetterKey.E:
                    return new char[] {'ë', '€' };
                case LetterKey.G:
                    return new char[] { 'ğ' };
                case LetterKey.I:
                    return new char[] { 'î', 'ï' };
                case LetterKey.O:
                    return new char[] { 'ö', 'ô' };
                case LetterKey.S:
                    return new char[] { 'ş' };
                case LetterKey.T:
                    return new char[] { '₺' };
                case LetterKey.U:
                    return new char[] { 'ñ', 'ü', 'û' };
                case LetterKey.Y:
                    return new char[] { 'ÿ', 'ý' };
            }

            return Array.Empty<char>();
        }

        // Polish
        private static char[] GetDefaultLetterKeyPL(LetterKey letter)
        {
            switch (letter)
            {
                case LetterKey.A:
                    return new char[] { 'ą' };
                case LetterKey.C:
                    return new char[] { 'ć' };
                case LetterKey.E:
                    return new char[] { 'ę', '€' };
                case LetterKey.L:
                    return new char[] { 'ł' };
                case LetterKey.N:
                    return new char[] { 'ń' };
                case LetterKey.O:
                    return new char[] { 'ó' };
                case LetterKey.S:
                    return new char[] { 'ś' };
                case LetterKey.Z:
                    return new char[] { 'ź', 'ż' };
            }

            return Array.Empty<char>();
        }
    }
}
