using System;
using System.Globalization;

namespace Localization4WPF
{
    public interface ILocalizationService
    {
        string Get(string key, CultureInfo cultureInfo = null);
        void Register(string folder, UriKind kind, CultureInfo cultureInfo = null);
        void Register(string key, string text, CultureInfo cultureInfo = null);
    }
}