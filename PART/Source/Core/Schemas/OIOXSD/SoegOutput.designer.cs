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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:oio:sagdok:2.0.0")]
    [System.Xml.Serialization.XmlRootAttribute("SoegOutput", Namespace="urn:oio:sagdok:person:1.0.0", IsNullable=false)]
    public partial class SoegOutputType {
        
        private StandardReturType standardReturField;
        
        private string[] idlisteField;
        
        /// <remarks/>
        public StandardReturType StandardRetur {
            get {
                return this.standardReturField;
            }
            set {
                this.standardReturField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Namespace="urn:oio:sagdok:1.0.0")]
        [System.Xml.Serialization.XmlArrayItemAttribute("UUID", Namespace="urn:oio:dkal:1.0.0", IsNullable=false)]
        public string[] Idliste {
            get {
                return this.idlisteField;
            }
            set {
                this.idlisteField = value;
            }
        }
    }
}