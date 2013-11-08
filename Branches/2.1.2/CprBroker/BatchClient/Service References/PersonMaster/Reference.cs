﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BatchClient.PersonMaster {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://personmaster.gentofte.dk/BasicOp/01", ConfigurationName="PersonMaster.IBasicOp")]
    public interface IBasicOp {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://personmaster.gentofte.dk/BasicOp/01/IBasicOp/CreateObjectOwner", ReplyAction="http://personmaster.gentofte.dk/BasicOp/01/IBasicOp/CreateObjectOwnerResponse")]
        System.Guid CreateObjectOwner(string context, string nameSpace, System.Guid objectOwnerID, ref string aux);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://personmaster.gentofte.dk/BasicOp/01/IBasicOp/GetObjectOwnerIDFromNamespace" +
            "", ReplyAction="http://personmaster.gentofte.dk/BasicOp/01/IBasicOp/GetObjectOwnerIDFromNamespace" +
            "Response")]
        System.Guid GetObjectOwnerIDFromNamespace(string context, string nameSpace, ref string aux);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://personmaster.gentofte.dk/BasicOp/01/IBasicOp/GetObjectIDFromCpr", ReplyAction="http://personmaster.gentofte.dk/BasicOp/01/IBasicOp/GetObjectIDFromCprResponse")]
        System.Guid GetObjectIDFromCpr(string context, string cprNo, ref string aux);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://personmaster.gentofte.dk/BasicOp/01/IBasicOp/GetObjectIDsFromCprArray", ReplyAction="http://personmaster.gentofte.dk/BasicOp/01/IBasicOp/GetObjectIDsFromCprArrayRespo" +
            "nse")]
        System.Nullable<System.Guid>[] GetObjectIDsFromCprArray(string context, string[] cprNoArr, ref string aux);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://personmaster.gentofte.dk/BasicOp/01/IBasicOp/GetObjectIDFromCprWithOwner", ReplyAction="http://personmaster.gentofte.dk/BasicOp/01/IBasicOp/GetObjectIDFromCprWithOwnerRe" +
            "sponse")]
        System.Guid GetObjectIDFromCprWithOwner(string context, string cprNo, System.Guid objectOwnerID, ref string aux);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://personmaster.gentofte.dk/BasicOp/01/IBasicOp/GetCprFromObjectID", ReplyAction="http://personmaster.gentofte.dk/BasicOp/01/IBasicOp/GetCprFromObjectIDResponse")]
        string GetCprFromObjectID(string context, System.Guid objectID, ref string aux);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://personmaster.gentofte.dk/BasicOp/01/IBasicOp/MapCpr2Loginname", ReplyAction="http://personmaster.gentofte.dk/BasicOp/01/IBasicOp/MapCpr2LoginnameResponse")]
        void MapCpr2Loginname(string context, string cprNo, string loginName, ref string aux);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://personmaster.gentofte.dk/BasicOp/01/IBasicOp/RenameLoginname", ReplyAction="http://personmaster.gentofte.dk/BasicOp/01/IBasicOp/RenameLoginnameResponse")]
        void RenameLoginname(string context, string oldLoginName, string newLoginName, ref string aux);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://personmaster.gentofte.dk/BasicOp/01/IBasicOp/DeleteLoginname", ReplyAction="http://personmaster.gentofte.dk/BasicOp/01/IBasicOp/DeleteLoginnameResponse")]
        void DeleteLoginname(string context, string loginName, ref string aux);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://personmaster.gentofte.dk/BasicOp/01/IBasicOp/LoginnameExist", ReplyAction="http://personmaster.gentofte.dk/BasicOp/01/IBasicOp/LoginnameExistResponse")]
        bool LoginnameExist(string context, string loginName, ref string aux);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://personmaster.gentofte.dk/BasicOp/01/IBasicOp/GetPreferredLoginnameFromCpr", ReplyAction="http://personmaster.gentofte.dk/BasicOp/01/IBasicOp/GetPreferredLoginnameFromCprR" +
            "esponse")]
        string GetPreferredLoginnameFromCpr(string context, string cprNo, ref string aux);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://personmaster.gentofte.dk/BasicOp/01/IBasicOp/SetPreferredLoginname", ReplyAction="http://personmaster.gentofte.dk/BasicOp/01/IBasicOp/SetPreferredLoginnameResponse" +
            "")]
        void SetPreferredLoginname(string context, string cprNo, string loginName, ref string aux);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://personmaster.gentofte.dk/BasicOp/01/IBasicOp/GetAllLoginnamesFromCpr", ReplyAction="http://personmaster.gentofte.dk/BasicOp/01/IBasicOp/GetAllLoginnamesFromCprRespon" +
            "se")]
        string[] GetAllLoginnamesFromCpr(string context, string cprNo, ref string aux);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://personmaster.gentofte.dk/BasicOp/01/IBasicOp/GetCprFromLoginname", ReplyAction="http://personmaster.gentofte.dk/BasicOp/01/IBasicOp/GetCprFromLoginnameResponse")]
        string GetCprFromLoginname(string context, string loginName, ref string aux);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://personmaster.gentofte.dk/BasicOp/01/IBasicOp/Probe", ReplyAction="http://personmaster.gentofte.dk/BasicOp/01/IBasicOp/ProbeResponse")]
        string Probe(string context, ref string aux);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://personmaster.gentofte.dk/BasicOp/01/IBasicOp/GetDBRuntimeInfo", ReplyAction="http://personmaster.gentofte.dk/BasicOp/01/IBasicOp/GetDBRuntimeInfoResponse")]
        void GetDBRuntimeInfo(string context, ref string aux);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://personmaster.gentofte.dk/BasicOp/01/IBasicOp/RegisterNonAdminUser", ReplyAction="http://personmaster.gentofte.dk/BasicOp/01/IBasicOp/RegisterNonAdminUserResponse")]
        void RegisterNonAdminUser(string context, string cprNo, ref string aux);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://personmaster.gentofte.dk/BasicOp/01/IBasicOp/UnRegisterNonAdminUser", ReplyAction="http://personmaster.gentofte.dk/BasicOp/01/IBasicOp/UnRegisterNonAdminUserRespons" +
            "e")]
        void UnRegisterNonAdminUser(string context, string cprNo, ref string aux);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://personmaster.gentofte.dk/BasicOp/01/IBasicOp/IsRegisteredNonAdminUser", ReplyAction="http://personmaster.gentofte.dk/BasicOp/01/IBasicOp/IsRegisteredNonAdminUserRespo" +
            "nse")]
        bool IsRegisteredNonAdminUser(string context, string cprNo, ref string aux);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBasicOpChannel : BatchClient.PersonMaster.IBasicOp, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BasicOpClient : System.ServiceModel.ClientBase<BatchClient.PersonMaster.IBasicOp>, BatchClient.PersonMaster.IBasicOp {
        
        public BasicOpClient() {
        }
        
        public BasicOpClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BasicOpClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BasicOpClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BasicOpClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Guid CreateObjectOwner(string context, string nameSpace, System.Guid objectOwnerID, ref string aux) {
            return base.Channel.CreateObjectOwner(context, nameSpace, objectOwnerID, ref aux);
        }
        
        public System.Guid GetObjectOwnerIDFromNamespace(string context, string nameSpace, ref string aux) {
            return base.Channel.GetObjectOwnerIDFromNamespace(context, nameSpace, ref aux);
        }
        
        public System.Guid GetObjectIDFromCpr(string context, string cprNo, ref string aux) {
            return base.Channel.GetObjectIDFromCpr(context, cprNo, ref aux);
        }
        
        public System.Nullable<System.Guid>[] GetObjectIDsFromCprArray(string context, string[] cprNoArr, ref string aux) {
            return base.Channel.GetObjectIDsFromCprArray(context, cprNoArr, ref aux);
        }
        
        public System.Guid GetObjectIDFromCprWithOwner(string context, string cprNo, System.Guid objectOwnerID, ref string aux) {
            return base.Channel.GetObjectIDFromCprWithOwner(context, cprNo, objectOwnerID, ref aux);
        }
        
        public string GetCprFromObjectID(string context, System.Guid objectID, ref string aux) {
            return base.Channel.GetCprFromObjectID(context, objectID, ref aux);
        }
        
        public void MapCpr2Loginname(string context, string cprNo, string loginName, ref string aux) {
            base.Channel.MapCpr2Loginname(context, cprNo, loginName, ref aux);
        }
        
        public void RenameLoginname(string context, string oldLoginName, string newLoginName, ref string aux) {
            base.Channel.RenameLoginname(context, oldLoginName, newLoginName, ref aux);
        }
        
        public void DeleteLoginname(string context, string loginName, ref string aux) {
            base.Channel.DeleteLoginname(context, loginName, ref aux);
        }
        
        public bool LoginnameExist(string context, string loginName, ref string aux) {
            return base.Channel.LoginnameExist(context, loginName, ref aux);
        }
        
        public string GetPreferredLoginnameFromCpr(string context, string cprNo, ref string aux) {
            return base.Channel.GetPreferredLoginnameFromCpr(context, cprNo, ref aux);
        }
        
        public void SetPreferredLoginname(string context, string cprNo, string loginName, ref string aux) {
            base.Channel.SetPreferredLoginname(context, cprNo, loginName, ref aux);
        }
        
        public string[] GetAllLoginnamesFromCpr(string context, string cprNo, ref string aux) {
            return base.Channel.GetAllLoginnamesFromCpr(context, cprNo, ref aux);
        }
        
        public string GetCprFromLoginname(string context, string loginName, ref string aux) {
            return base.Channel.GetCprFromLoginname(context, loginName, ref aux);
        }
        
        public string Probe(string context, ref string aux) {
            return base.Channel.Probe(context, ref aux);
        }
        
        public void GetDBRuntimeInfo(string context, ref string aux) {
            base.Channel.GetDBRuntimeInfo(context, ref aux);
        }
        
        public void RegisterNonAdminUser(string context, string cprNo, ref string aux) {
            base.Channel.RegisterNonAdminUser(context, cprNo, ref aux);
        }
        
        public void UnRegisterNonAdminUser(string context, string cprNo, ref string aux) {
            base.Channel.UnRegisterNonAdminUser(context, cprNo, ref aux);
        }
        
        public bool IsRegisteredNonAdminUser(string context, string cprNo, ref string aux) {
            return base.Channel.IsRegisteredNonAdminUser(context, cprNo, ref aux);
        }
    }
}
