//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=2.0.50727.3038.
// 
namespace CprBroker.Schemas.Part {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://rep.oio.dk/xkom.dk/xml/schemas/2005/03/15/")]
    [System.Xml.Serialization.XmlRootAttribute("AddressAccess", Namespace="http://rep.oio.dk/xkom.dk/xml/schemas/2005/03/15/", IsNullable=false)]
    public partial class AddressAccessType {
        
        private string municipalityCodeField;
        
        private string streetCodeField;
        
        private string streetBuildingIdentifierField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace="http://rep.oio.dk/cpr.dk/xml/schemas/core/2005/03/18/")]
        public string MunicipalityCode {
            get {
                return this.municipalityCodeField;
            }
            set {
                this.municipalityCodeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace="http://rep.oio.dk/cpr.dk/xml/schemas/core/2005/03/18/")]
        public string StreetCode {
            get {
                return this.streetCodeField;
            }
            set {
                this.streetCodeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace="http://rep.oio.dk/ebxml/xml/schemas/dkcc/2003/02/13/")]
        public string StreetBuildingIdentifier {
            get {
                return this.streetBuildingIdentifierField;
            }
            set {
                this.streetBuildingIdentifierField = value;
            }
        }
    }
}