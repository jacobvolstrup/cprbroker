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
    [System.Xml.Serialization.XmlRootAttribute("AddressPointStatusStructure", Namespace="http://rep.oio.dk/bbr.dk/xml/schemas/2006/09/30/", IsNullable=false)]
    public partial class AddressPointStatusStructureType {
        
        private System.DateTime addressPointRevisionDateTimeField;
        
        private System.DateTime addressPointValidStartDateTimeField;
        
        private bool addressPointValidStartDateTimeFieldSpecified;
        
        private System.DateTime addressPointValidEndDateTimeField;
        
        private bool addressPointValidEndDateTimeFieldSpecified;
        
        private AddressCoordinateQualityClassCodeType addressCoordinateQualityClassCodeField;
        
        private bool addressCoordinateQualityClassCodeFieldSpecified;
        
        /// <remarks/>
        public System.DateTime AddressPointRevisionDateTime {
            get {
                return this.addressPointRevisionDateTimeField;
            }
            set {
                this.addressPointRevisionDateTimeField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime AddressPointValidStartDateTime {
            get {
                return this.addressPointValidStartDateTimeField;
            }
            set {
                this.addressPointValidStartDateTimeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AddressPointValidStartDateTimeSpecified {
            get {
                return this.addressPointValidStartDateTimeFieldSpecified;
            }
            set {
                this.addressPointValidStartDateTimeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime AddressPointValidEndDateTime {
            get {
                return this.addressPointValidEndDateTimeField;
            }
            set {
                this.addressPointValidEndDateTimeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AddressPointValidEndDateTimeSpecified {
            get {
                return this.addressPointValidEndDateTimeFieldSpecified;
            }
            set {
                this.addressPointValidEndDateTimeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public AddressCoordinateQualityClassCodeType AddressCoordinateQualityClassCode {
            get {
                return this.addressCoordinateQualityClassCodeField;
            }
            set {
                this.addressCoordinateQualityClassCodeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AddressCoordinateQualityClassCodeSpecified {
            get {
                return this.addressCoordinateQualityClassCodeFieldSpecified;
            }
            set {
                this.addressCoordinateQualityClassCodeFieldSpecified = value;
            }
        }
    }
}