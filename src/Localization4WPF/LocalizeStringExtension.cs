using System;
using System.Windows.Markup;

namespace Localization4WPF
{
    [MarkupExtensionReturnType( typeof( string ) )]
    public class LocalizeStringExtension : MarkupExtension
    {
        public LocalizeStringExtension()
        {
        }

        public LocalizeStringExtension(string key)
        {
            Key = key;
        }

        // ------------------------------------------------------------------

        [ConstructorArgument("key")]
        public string Key { get; set; }

        // ------------------------------------------------------------------

        #region Overrides of MarkupExtension

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if( LocalizationService.Instance == null )
            {
                return Key;
            }
            return LocalizationService.Instance.Get( Key );
        }

        #endregion Overrides of MarkupExtension
    }
}
