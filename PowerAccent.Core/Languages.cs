namespace PowerAccent.Core;

/// <summary>
/// Languages, ordered alphabetically by country code (except ALL & Currency). It is set the order of the flags in the settings.
/// </summary>
public enum Language
{
    ALL,
    CUR,
    CY,
    CZ,
    DE,
    FI,
    FR,
    HR,
    HU,
    IS,
    IT,
    JP,
    MI,
    NL,
    PI,
    PL,
    PT,
    RO,
    RS,
    SA,
    SK,
    SP,
    SV,
    TK,
}

internal static class Languages
{
    public static char[] GetMultipleLetterKey(LetterKey letter, Language[] langs)
    {
        var multipleLetterKey = new List<char[]>();
        foreach (var lang in langs)
        {
            multipleLetterKey.Add(GetDefaultLetterKey(letter, lang));
        }

        var result = new List<char>();
        for (int i = 0; i < multipleLetterKey.Max(x => x.Length); i++)
        {
            for (int j = 0; j < multipleLetterKey.Count; j++)
            {
                if (i < multipleLetterKey[j].Length)
                {
                    result.Add(multipleLetterKey[j][i]);
                }

                if (j > multipleLetterKey.Count)
                    j = 0;
            }
        }

        // remove duplicate
        int index = 0;
        while (index < result.Count)
        {
            int index2 = result.FindIndex(index + 1, x => x == result[index]);
            if (index2 != -1)
            {
                result.RemoveAt(index);
            }
            else
            {
                index++;
            }
        }

        return result.ToArray();
    }

    public static char[] GetDefaultLetterKey(LetterKey letter, Language lang)
    {
        switch (lang)
        {
            case Language.ALL: return GetDefaultLetterKeyALL(letter); // ALL
            case Language.CUR: return GetDefaultLetterKeyCUR(letter); // Currency
            case Language.CY: return GetDefaultLetterKeyCY(letter); // Welsh
            case Language.CZ: return GetDefaultLetterKeyCZ(letter); // Czech
            case Language.DE: return GetDefaultLetterKeyDE(letter); // Germany
            case Language.FI: return GetDefaultLetterKeyFI(letter); // Finnish
            case Language.FR: return GetDefaultLetterKeyFR(letter); // French
            case Language.HR: return GetDefaultLetterKeyHR(letter); // Croatian
            case Language.HU: return GetDefaultLetterKeyHU(letter); // Hungarian
            case Language.IS: return GetDefaultLetterKeyIS(letter); // Iceland
            case Language.IT: return GetDefaultLetterKeyIT(letter); // Italian
            case Language.JP: return GetDefaultLetterKeyJP(letter); // Japanese
            case Language.MI: return GetDefaultLetterKeyMI(letter); // Maori
            case Language.NL: return GetDefaultLetterKeyNL(letter); // Netherlands
            case Language.PI: return GetDefaultLetterKeyPI(letter); // Pinyin
            case Language.PL: return GetDefaultLetterKeyPL(letter); // Polish
            case Language.PT: return GetDefaultLetterKeyPT(letter); // Portuguese
            case Language.RO: return GetDefaultLetterKeyRO(letter); // Romanian
            case Language.RS: return GetDefaultLetterKeySR(letter); // Serbian
            case Language.SA: return GetDefaultLetterKeySA(letter); // Sanskrit
            case Language.SK: return GetDefaultLetterKeySK(letter); // Slovak
            case Language.SP: return GetDefaultLetterKeySP(letter); // Spain
            case Language.SV: return GetDefaultLetterKeySV(letter); // Swedish
            case Language.TK: return GetDefaultLetterKeyTK(letter); // Turkish
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
                return new char[] { 'á', 'à', 'ä', 'â', 'ă', 'å', 'α', 'ā', 'ą', 'ȧ', 'ã', 'æ' };
            case LetterKey.B:
                return new char[] { 'ḃ', 'β' };
            case LetterKey.C:
                return new char[] { 'ç', 'ć', 'ĉ', 'č', 'ċ', '¢', 'χ' };
            case LetterKey.D:
                return new char[] { 'ď', 'ḋ', 'đ', 'δ', 'ð' };
            case LetterKey.E:
                return new char[] { 'é', 'è', 'ê', 'ë', 'ě', 'ē', 'ę', 'ė', 'ε', 'η', '€' };
            case LetterKey.F:
                return new char[] { 'ƒ', 'ḟ' };
            case LetterKey.G:
                return new char[] { 'ğ', 'ģ', 'ǧ', 'ġ', 'ĝ', 'ǥ', 'γ' };
            case LetterKey.H:
                return new char[] { 'ḣ', 'ĥ', 'ħ' };
            case LetterKey.I:
                return new char[] { 'ï', 'î', 'í', 'ì', 'ī', 'į', 'i', 'ı', 'İ', 'ι' };
            case LetterKey.J:
                return new char[] { 'ĵ' };
            case LetterKey.K:
                return new char[] { 'ķ', 'ǩ', 'κ' };
            case LetterKey.L:
                return new char[] { 'ĺ', 'ľ', 'ļ', 'ł', '₺', 'λ' };
            case LetterKey.M:
                return new char[] { 'ṁ' };
            case LetterKey.N:
                return new char[] { 'ñ', 'ń', 'ŋ', 'ň', 'ņ', 'ṅ', 'ⁿ', 'ν' };
            case LetterKey.O:
                return new char[] { 'ô', 'ó', 'ö', 'ő', 'ò', 'ō', 'ȯ', 'ø', 'õ', 'œ', 'ω' };
            case LetterKey.P:
                return new char[] { 'ṗ', '₽', 'π', 'φ', 'ψ' };
            case LetterKey.R:
                return new char[] { 'ŕ', 'ř', 'ṙ', '₹', 'ρ' };
            case LetterKey.S:
                return new char[] { 'ś', 'ş', 'š', 'ș', 'ṡ', 'ŝ', 'ß', 'σ', '$' };
            case LetterKey.T:
                return new char[] { 'ţ', 'ť', 'ț', 'ṫ', 'ŧ', 'θ', 'τ' };
            case LetterKey.U:
                return new char[] { 'û', 'ú', 'ü', 'ŭ', 'ű', 'ù', 'ů', 'ū', 'ų' };
            case LetterKey.W:
                return new char[] { 'ẇ', 'ŵ', '₩' };
            case LetterKey.X:
                return new char[] { 'ẋ', 'ξ' };
            case LetterKey.Y:
                return new char[] { 'ÿ', 'ŷ', 'ý', 'ẏ' };
            case LetterKey.Z:
                return new char[] { 'ź', 'ž', 'ż', 'ʒ', 'ǯ', 'ζ' };
            case LetterKey._:
                return new char[] { '¿', '¡', '∙', '₋', '⁻', '–', '≤', '≥', '≠', '≈', '≙', '±', '₊', '⁺', 'þ' };
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

    //Croatian
    private static char[] GetDefaultLetterKeyHR(LetterKey letter)
    {
        switch (letter)
        {

            case LetterKey.C:
                return new char[] { 'ć', 'č' };
            case LetterKey.D:
                return new char[] { 'đ' };
            case LetterKey.S:
                return new char[] { 'š' };
            case LetterKey.Z:
                return new char[] { 'ž' };
        }

        return Array.Empty<char>();
    }

    // Finnish
    private static char[] GetDefaultLetterKeyFI(LetterKey letter)
    {
        switch (letter)
        {
            case LetterKey.A:
                return new char[] { 'ä', 'å' };
            case LetterKey.E:
                return new char[] { '€' };
            case LetterKey.O:
                return new char[] { 'ö' };
        }

        return Array.Empty<char>();
    }

    // French
    private static char[] GetDefaultLetterKeyFR(LetterKey letter)
    {
        switch (letter)
        {
            case LetterKey.A:
                return new char[] { 'à', 'â', 'á', 'ä', 'ã', 'æ' };
            case LetterKey.C:
                return new char[] { 'ç' };
            case LetterKey.E:
                return new char[] { 'é', 'è', 'ê', 'ë', '€' };
            case LetterKey.I:
                return new char[] { 'î', 'ï', 'í', 'ì' };
            case LetterKey.O:
                return new char[] { 'ô', 'ö', 'ó', 'ò', 'õ', 'œ' };
            case LetterKey.U:
                return new char[] { 'û', 'ù', 'ü', 'ú' };
            case LetterKey.Y:
                return new char[] { 'ÿ', 'ý' };
        }

        return Array.Empty<char>();
    }

    // Icelandic
    private static char[] GetDefaultLetterKeyIS(LetterKey letter)
    {
        switch (letter)
        {
            case LetterKey.A: return new char[] { 'á', 'æ' };
            case LetterKey.D: return new char[] { 'ð' };
            case LetterKey.E: return new char[] { 'é' };
            case LetterKey.O: return new char[] { 'ó', 'ö' };
            case LetterKey.U: return new char[] { 'ú' };
            case LetterKey.Y: return new char[] { 'ý' };
            case LetterKey._: return new char[] { 'þ' };
        }

        return Array.Empty<char>();
    }

    // Spanish
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
                return new char[] { 'ú', 'ü' };
            case LetterKey._:
                return new char[] { '¿', '¡' };
        }

        return Array.Empty<char>();
    }

    // Swedish
    private static char[] GetDefaultLetterKeySV(LetterKey letter)
    {
        switch (letter)
        {
            case LetterKey.A:
                return new char[] { 'å', 'ä' };
            case LetterKey.O:
                return new char[] { 'ö' };
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

    // Netherlands
    private static char[] GetDefaultLetterKeyNL(LetterKey letter)
    {
        switch (letter)
        {
            case LetterKey.A:
                return new char[] { 'á', 'à', 'ä' };
            case LetterKey.C:
                return new char[] { 'ç' };
            case LetterKey.E:
                return new char[] { 'é', 'è', 'ë', 'ê', '€' };
            case LetterKey.I:
                return new char[] { 'í', 'ï', 'î' };
            case LetterKey.N:
                return new char[] { 'ñ' };
            case LetterKey.O:
                return new char[] { 'ó', 'ö', 'ô' };
            case LetterKey.U:
                return new char[] { 'ú', 'ü', 'û' };
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
                return new char[] { 'â' };
            case LetterKey.C:
                return new char[] { 'ç' };
            case LetterKey.E:
                return new char[] { 'ë', '€' };
            case LetterKey.G:
                return new char[] { 'ğ' };
            case LetterKey.I:
                return new char[] { 'ı', 'İ', 'î' };
            case LetterKey.L:
                return new char[] { '₺' };
            case LetterKey.O:
                return new char[] { 'ö', 'ô' };
            case LetterKey.S:
                return new char[] { 'ş' };
            case LetterKey.U:
                return new char[] { 'ü', 'û' };
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
                return new char[] { 'ż', 'ź' };
        }

        return Array.Empty<char>();
    }

    // Portuguese
    private static char[] GetDefaultLetterKeyPT(LetterKey letter)
    {
        switch (letter)
        {
            case LetterKey.A:
                return new char[] { 'á', 'à', 'â', 'ã' };
            case LetterKey.C:
                return new char[] { 'ç' };
            case LetterKey.E:
                return new char[] { 'é', 'ê', '€' };
            case LetterKey.I:
                return new char[] { 'í' };
            case LetterKey.O:
                return new char[] { 'ó', 'ô', 'õ' };
            case LetterKey.P:
                return new char[] { 'π' };
            case LetterKey.U:
                return new char[] { 'ú', 'ü' };
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

    // Germany
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

    // Hungarian
    private static char[] GetDefaultLetterKeyHU(LetterKey letter)
    {
        switch (letter)
        {
            case LetterKey.A:
                return new char[] { 'á' };
            case LetterKey.E:
                return new char[] { 'é' };
            case LetterKey.I:
                return new char[] { 'í' };
            case LetterKey.O:
                return new char[] { 'ó', 'ő', 'ö' };
            case LetterKey.U:
                return new char[] { 'ú', 'ű', 'ü' };
        }

        return Array.Empty<char>();
    }

    // Romanian
    private static char[] GetDefaultLetterKeyRO(LetterKey letter)
    {
        switch (letter)
        {
            case LetterKey.A:
                return new char[] { 'ă', 'â' };
            case LetterKey.I:
                return new char[] { 'î' };
            case LetterKey.S:
                return new char[] { 'ș' };
            case LetterKey.T:
                return new char[] { 'ț' };
        }

        return Array.Empty<char>();
    }

    // Italian
    private static char[] GetDefaultLetterKeyIT(LetterKey letter)
    {
        switch (letter)
        {
            case LetterKey.A:
                return new char[] { 'à' };
            case LetterKey.E:
                return new char[] { 'è', 'é', '€' };
            case LetterKey.I:
                return new char[] { 'ì', 'í' };
            case LetterKey.O:
                return new char[] { 'ò', 'ó' };
            case LetterKey.U:
                return new char[] { 'ù', 'ú' };
        }

        return Array.Empty<char>();
    }

    // Japanese
    private static char[] GetDefaultLetterKeyJP(LetterKey letter)
    {
        switch (letter)
        {
            case LetterKey.A:
                return new char[] { 'ā', 'â' };
            case LetterKey.E:
                return new char[] { 'ē', 'ê' };
            case LetterKey.I:
                return new char[] { 'ī', 'î' };
            case LetterKey.O:
                return new char[] { 'ō', 'ô' };
            case LetterKey.U:
                return new char[] { 'ū', 'û' };
            case LetterKey.Y:
                return new char[] { '¥' };
        }

        return Array.Empty<char>();
    }

    // Welsh
    private static char[] GetDefaultLetterKeyCY(LetterKey letter)
    {
        switch (letter)
        {
            case LetterKey.A:
                return new char[] { 'â' };
            case LetterKey.E:
                return new char[] { 'ê' };
            case LetterKey.I:
                return new char[] { 'î' };
            case LetterKey.O:
                return new char[] { 'ô' };
            case LetterKey.U:
                return new char[] { 'û' };
            case LetterKey.Y:
                return new char[] { 'ŷ' };
            case LetterKey.W:
                return new char[] { 'ŵ' };
        }

        return Array.Empty<char>();
    }

    // Serbian
    private static char[] GetDefaultLetterKeySR(LetterKey letter)
    {
        switch (letter)
        {
            case LetterKey.C:
                return new char[] { 'ć', 'č' };
            case LetterKey.D:
                return new char[] { 'đ' };
            case LetterKey.S:
                return new char[] { 'š' };
            case LetterKey.Z:
                return new char[] { 'ž' };
        }

        return Array.Empty<char>();
    }

    // Sanskrit
    private static char[] GetDefaultLetterKeySA(LetterKey letter)
    {
        switch (letter)
        {
            case LetterKey.A:
                return new char[] { 'ā', 'ǣ' };
            case LetterKey.C:
                return new char[] { 'ĉ' };
            case LetterKey.D:
                return new char[] { 'ḍ' };
            case LetterKey.E:
                return new char[] { 'ē', 'ê' };
            case LetterKey.G:
                return new char[] { 'ġ' };
            case LetterKey.H:
                return new char[] { 'ḥ', 'ẖ', 'ḫ' };
            case LetterKey.I:
                return new char[] { 'ī' };
            case LetterKey.K:
                return new char[] { 'ḵ' };
            case LetterKey.L:
                return new char[] { 'ḷ', 'ḻ' };
            case LetterKey.M:
                return new char[] { 'ṃ', 'ṁ' };
            case LetterKey.N:
                return new char[] { 'ṅ', 'ñ' };
            case LetterKey.O:
                return new char[] { 'ō', 'ô' };
            case LetterKey.R:
                return new char[] { 'ṛ', 'ṝ', 'ṟ', 'ṙ' };
            case LetterKey.S:
                return new char[] { 'ś', 'ṣ' };
            case LetterKey.T:
                return new char[] { 'ṭ', 'ṯ' };
            case LetterKey.U:
                return new char[] { 'ū', 'ŭ' };
            case LetterKey.Y:
                return new char[] { 'ẏ' };
            case LetterKey.Z:
                return new char[] { 'ẓ', 'ẕ', 'ź', 'ž' };
        }

        return Array.Empty<char>();
    }

}
