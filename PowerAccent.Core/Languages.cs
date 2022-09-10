namespace PowerAccent.Core;

public enum Language
{
    ALL,
    CUR,
    CZ,
    DE,
    FR,
    MI,
    PI,
    PL,
    SK,
    SP,
    TK,
}

internal static class Languages
{
    public static char[] GetDefaultLetterKey(LetterKey letter, Language lang)
    {
        switch (lang)
        {
            case Language.ALL: return GetDefaultLetterKeyALL(letter);
            case Language.CUR: return GetDefaultLetterKeyCUR(letter);
            case Language.CZ: return GetDefaultLetterKeyCZ(letter);
            case Language.DE: return GetDefaultLetterKeyDE(letter);
            case Language.FR: return GetDefaultLetterKeyFR(letter);
            case Language.MI: return GetDefaultLetterKeyMI(letter);
            case Language.PI: return GetDefaultLetterKeyPI(letter);
            case Language.PL: return GetDefaultLetterKeyPL(letter);
            case Language.SK: return GetDefaultLetterKeySK(letter);
            case Language.SP: return GetDefaultLetterKeySP(letter);
            case Language.TK: return GetDefaultLetterKeyTK(letter);
        }

        throw new ArgumentException("The language {0} is not know in this context", lang.ToString());
    }

    public static string GetFlag(Language lang)
    {
        return string.Concat(lang.ToString().ToUpper().Select(x => char.ConvertFromUtf32(x + 0x1F1A5)));
    }

    // All
    private static char[] GetDefaultLetterKeyALL(LetterKey letter)
    {
        switch (letter)
        {
            case LetterKey._0:
				    return new char[] { '₀', '⁰' };
            case LetterKey._1:
				    return new char[] { '₁', '¹' };
            case LetterKey._2:
				    return new char[] { '₂', '²' };
            case LetterKey._3:
				    return new char[] { '₃', '³' };
            case LetterKey._4:
				    return new char[] { '₄', '⁴' };
            case LetterKey._5:
				    return new char[] { '₅', '⁵' };
            case LetterKey._6:
				    return new char[] { '₆', '⁶' };
            case LetterKey._7:
				    return new char[] { '₇', '⁷' };
            case LetterKey._8:
				    return new char[] { '₈', '⁸' };
            case LetterKey._9:
				    return new char[] { '₉', '⁹' };
            case LetterKey.A:
                return new char[] { 'á', 'à', 'ä', 'â', 'ă', 'å', 'ā', 'ą', 'ȧ', 'ã' };
            case LetterKey.B:
                return new char[] { 'ḃ' };
            case LetterKey.C:
                return new char[] { 'ç', 'ć', 'ĉ', 'č', 'ċ', '¢' };
            case LetterKey.D:
                return new char[] { 'ď', 'ḋ', 'đ' };
            case LetterKey.E:
                return new char[] { 'é', 'è', 'ê', 'ë', 'ě', 'ē', 'ę', 'ė' };
            case LetterKey.F:
                return new char[] { 'ƒ', 'ḟ' };
            case LetterKey.G:
                return new char[] { 'ğ', 'ģ', 'ǧ', 'ġ', 'ĝ', 'ǥ' };
            case LetterKey.H:
                return new char[] { 'ḣ', 'ĥ', 'ħ' };
            case LetterKey.I:
                return new char[] { 'ï', 'î', 'í', 'ì', 'ī', 'į', 'i' };
            case LetterKey.J:
                return new char[] { 'ĵ' };
            case LetterKey.K:
                return new char[] { 'ķ', 'ǩ' };
            case LetterKey.L:
                return new char[] { 'ĺ', 'ľ', 'ļ', 'ł' };
            case LetterKey.M:
                return new char[] { 'ṁ' };
            case LetterKey.N:
                return new char[] { 'ñ', 'ń', 'ŋ', 'ň', 'ņ', 'ṅ',  'ⁿ' };
            case LetterKey.O:
                return new char[] { 'ô', 'ó', 'ö', 'ő', 'ò', 'ō', 'ȯ', 'ø', 'õ' };
            case LetterKey.P:
                return new char[] { 'ṗ', '₽' };
            case LetterKey.R:
                return new char[] { 'ŕ', 'ř', 'ṙ', '₹' };
            case LetterKey.S:
                return new char[] { 'ś', 'ş', 'š', 'ș', 'ṡ', 'ŝ', '$' };
            case LetterKey.T:
                return new char[] { 'ţ', 'ť', 'ț', 'ṫ', 'ŧ' };
            case LetterKey.U:
                return new char[] { 'û', 'ú', 'ü', 'ŭ', 'ű', 'ù', 'ů', 'ū', 'ų' };
            case LetterKey.W:
                return new char[] { 'ẇ', 'ŵ', '₩' };
            case LetterKey.X:
                return new char[] { 'ẋ' };
            case LetterKey.Y:
                return new char[] { 'ÿ', 'ŷ', 'ý', 'ẏ' };
            case LetterKey.Z:
                return new char[] { 'ź', 'ž', 'ż', 'ʒ', 'ǯ' };
            case LetterKey._:
                return new char[] { '¿', '¡', '∙', '₋', '⁻', '–', '≤', '≥', '≠', '≈', '≙', '±', '₊', '⁺' };
        }

        return Array.Empty<char>();
    }

    // Currencies (source: https://www.eurochange.co.uk/travel-money/world-currency-abbreviations-symbols-and-codes-travel-money)
    private static char[] GetDefaultLetterKeyCUR(LetterKey letter)
    {
        switch (letter)
        {
            case LetterKey.B:
                return new char[] { '฿', 'в' };
            case LetterKey.C:
                return new char[] { '¢', '₡', 'č' };
            case LetterKey.D:
                return new char[] { '₫' };
            case LetterKey.E:
                return new char[] { '€' };
            case LetterKey.F:
                return new char[] { 'ƒ' };
            case LetterKey.H:
                return new char[] { '₴' };
            case LetterKey.K:
                return new char[] { '₭' };
            case LetterKey.L:
                return new char[] { 'ł' };
            case LetterKey.N:
                return new char[] { 'л' };
            case LetterKey.M:
                return new char[] { '₼' };
            case LetterKey.P:
                return new char[] { '£', '₽' };
            case LetterKey.R:
                return new char[] { '₹', '៛', '﷼' };
            case LetterKey.S:
                return new char[] { '$', '₪' };
            case LetterKey.T:
                return new char[] { '₮', '₺' };
            case LetterKey.W:
                return new char[] { '₩' };
            case LetterKey.Y:
                return new char[] { '¥' };
            case LetterKey.Z:
                return new char[] { 'z' };
        }

        return Array.Empty<char>();
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

    // Maori
    private static char[] GetDefaultLetterKeyMI(LetterKey letter)
    {
        switch (letter)
        {
            case LetterKey.A:
                return new char[] { 'ā' };
            case LetterKey.E:
                return new char[] { 'ē' };
            case LetterKey.I:
                return new char[] { 'ī' };
            case LetterKey.O:
                return new char[] { 'ō' };
            case LetterKey.S:
                return new char[] { '$' };
            case LetterKey.U:
                return new char[] { 'ū' };
        }

        return Array.Empty<char>();
    }

    // Pinyin
    private static char[] GetDefaultLetterKeyPI(LetterKey letter)
    {
        switch (letter)
        {
            case LetterKey.A:
                return new char[] { 'ā', 'á', 'ǎ', 'à', 'a' };
            case LetterKey.E:
                return new char[] { 'ē', 'é', 'ě', 'è', 'e' };
            case LetterKey.I:
                return new char[] { 'ī', 'í', 'ǐ', 'ì', 'i' };
            case LetterKey.O:
                return new char[] { 'ō', 'ó', 'ǒ', 'ò', 'o' };
            case LetterKey.U:
                return new char[] { 'ū', 'ú', 'ǔ', 'ù', 'u' };
            case LetterKey.V:
                return new char[] { 'ǖ', 'ǘ', 'ǚ', 'ǜ', 'ü' };
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

    // Slovak
    private static char[] GetDefaultLetterKeySK(LetterKey letter)
    {
        switch (letter)
        {
            case LetterKey.A:
                return new char[] { 'á', 'ä' };
            case LetterKey.C:
                return new char[] { 'č' };
            case LetterKey.D:
                return new char[] { 'ď' };
            case LetterKey.E:
                return new char[] { 'é', '€' };
            case LetterKey.I:
                return new char[] { 'í' };
            case LetterKey.L:
                return new char[] { 'ľ', 'ĺ' };
            case LetterKey.N:
                return new char[] { 'ň' };
            case LetterKey.O:
                return new char[] { 'ó', 'ô' };
            case LetterKey.R:
                return new char[] { 'ŕ' };
            case LetterKey.S:
                return new char[] { 'š' };
            case LetterKey.T:
                return new char[] { 'ť' };
            case LetterKey.U:
                return new char[] { 'ú' };
            case LetterKey.Y:
                return new char[] { 'ý' };
            case LetterKey.Z:
                return new char[] { 'ž' };
        }

        return Array.Empty<char>();
    }
    
    // Czech
    private static char[] GetDefaultLetterKeyCZ(LetterKey letter)
    {
        switch (letter)
        {
            case LetterKey.A:
                return new char[] { 'á' };
            case LetterKey.C:
                return new char[] { 'č' };
            case LetterKey.D:
                return new char[] { 'ď' };
            case LetterKey.E:
                return new char[] { 'ě', 'é' };
            case LetterKey.I:
                return new char[] { 'í' };
            case LetterKey.N:
                return new char[] { 'ň' };
            case LetterKey.O:
                return new char[] { 'ó' };
            case LetterKey.R:
                return new char[] { 'ř' };
            case LetterKey.S:
                return new char[] { 'š' };
            case LetterKey.T:
                return new char[] { 'ť' };
            case LetterKey.U:
                return new char[] { 'ů', 'ú' };
            case LetterKey.Y:
                return new char[] { 'ý' };
            case LetterKey.Z:
                return new char[] { 'ž' };
        }

        return Array.Empty<char>();
    }
    
    // German
    private static char[] GetDefaultLetterKeyDE(LetterKey letter)
    {
        switch (letter)
        {
            case LetterKey.A:
                return new char[] { 'ä' };
            case LetterKey.E:
                return new char[] { '€' };
            case LetterKey.O:
                return new char[] { 'ö' };
            case LetterKey.S:
                return new char[] { 'ß' };
            case LetterKey.U:
                return new char[] { 'ü' };
        }

        return Array.Empty<char>();
    }
}
