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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://rep.oio.dk/bbr.dk/xml/schemas/2006/09/30/")]
    [System.Xml.Serialization.XmlRootAttribute("GeographicCoordinateTuple", Namespace="http://rep.oio.dk/bbr.dk/xml/schemas/2006/09/30/", IsNullable=false)]
    public partial class GeographicCoordinateTupleType {
        
        private decimal geographicEastingMeasureField;
        
        private decimal geographicNorthingMeasureField;
        
        private decimal geographicHeightMeasureField;
        
        private bool geographicHeightMeasureFieldSpecified;
        
        /// <remarks/>
        public decimal GeographicEastingMeasure {
            get {
                return this.geographicEastingMeasureField;
            }
            set {
                this.geographicEastingMeasureField = value;
            }
        }
        
        /// <remarks/>
        public decimal GeographicNorthingMeasure {
            get {
                return this.geographicNorthingMeasureField;
            }
            set {
                this.geographicNorthingMeasureField = value;
            }
        }
        
        /// <remarks/>
        public decimal GeographicHeightMeasure {
            get {
                return this.geographicHeightMeasureField;
            }
            set {
                this.geographicHeightMeasureField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool GeographicHeightMeasureSpecified {
            get {
                return this.geographicHeightMeasureFieldSpecified;
            }
            set {
                this.geographicHeightMeasureFieldSpecified = value;
            }
        }
    }
}