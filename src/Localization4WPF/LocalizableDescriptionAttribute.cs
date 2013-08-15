using System;
using System.ComponentModel;
using System.Globalization;

namespace Localization4WPF
{
    [AttributeUsage( AttributeTargets.All, Inherited = false, AllowMultiple = true )]
    public sealed class LocalizableDescriptionAttribute : DescriptionAttribute
    {
        #region Fields

        private bool _isLocalized;

        #endregion Fields

        // ------------------------------------------------------------------

        #region Constructor

        public LocalizableDescriptionAttribute(string description)
            : base( description )
        {
        }

        #endregion Constructor

        // ------------------------------------------------------------------

        #region DescriptionAttribute Overrides Methods

        public override string Description
        {
            get
            {
                if( !_isLocalized )
                {
                    _isLocalized = true;

                    if( LocalizationService.Instance != null )
                    {
                        DescriptionValue = LocalizationService.Instance.Get( DescriptionValue, cultureInfo: CultureInfo.CurrentCulture );
                    }
                }
                return DescriptionValue;
            }
        }

        #endregion DescriptionAttribute Overrides Methods

    }
}