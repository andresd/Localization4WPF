using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Xml;
using System.Xml.Linq;

namespace Localization4WPF
{
    public class LocalizationService : ILocalizationService
    {
        #region Fields

        private readonly Dictionary<int, Dictionary<string, string>> _localizationTable;

        #endregion Fields

        // ------------------------------------------------------------------

        #region Constructor

        // ------------------------------------------------------------------

        public static ILocalizationService Instance { get; set; }

        // ------------------------------------------------------------------

        public LocalizationService()
        {
            _localizationTable = new Dictionary<int, Dictionary<string, string>>();
        }

        #endregion Constructor

        // ------------------------------------------------------------------

        #region Implementation of ILocalizationService

        public string Get(string key, CultureInfo cultureInfo = null)
        {
            int cultureLcid = CultureInfo.CurrentCulture.LCID;
            if( cultureInfo != null )
            {
                cultureLcid = cultureInfo.LCID;
            }
            if( _localizationTable.ContainsKey( cultureLcid ) )
            {
                if( _localizationTable[cultureLcid].ContainsKey( key ) )
                {
                    return _localizationTable[cultureLcid][key];
                }
            }
            return key;
        }

        // ------------------------------------------------------------------

        public void Register(string folder, UriKind kind, CultureInfo cultureInfo = null)
        {
            var language = cultureInfo != null ? cultureInfo.IetfLanguageTag + ".xml" : "en-us.xml";
            var uri = new Uri( string.Join( "/", new [] {folder.TrimEnd( '/' ), language } ), kind );

            var resourceStream = Application.GetResourceStream( uri );
            if( resourceStream != null )
            {
                using( var stream = resourceStream.Stream )
                {
                    using( var reader = XmlReader.Create( stream ) )
                    {
                        var xDoc = XDocument.Load( reader );
                        foreach( XElement element in xDoc.Descendants( "String" ) )
                        {
                            var key = element.Attribute( "Key" );
                            var value = element.Attribute( "Value" );
                            if( key != null )
                            {
                                Register( key.Value, value == null ? string.Empty : value.Value, CultureInfo.CurrentCulture );
                            }
                        }
                    }
                }
            }
        }

        // ------------------------------------------------------------------

        public void Register(string key, string text, CultureInfo cultureInfo = null)
        {
            int cultureLcid = CultureInfo.CurrentCulture.LCID;
            if( cultureInfo != null )
            {
                cultureLcid = cultureInfo.LCID;
            }
            if( !_localizationTable.ContainsKey( cultureLcid ) )
            {
                _localizationTable.Add( cultureLcid, new Dictionary<string, string>() );
            }
            if( !_localizationTable[cultureLcid].ContainsKey( key ) )
            {
                _localizationTable[cultureLcid].Add( key, text );
            }
            else
            {
                _localizationTable[cultureLcid][key] = text;
            }
        }

        #endregion Implementation of ILocalizationService
    }
}
