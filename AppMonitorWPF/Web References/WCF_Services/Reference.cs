﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace AppMonitorWPF.WCF_Services {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.81.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="BasicHttpBinding_IMonitorWCFService", Namespace="http://tempuri.org/")]
    public partial class MonitorWCFService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback IsAliveOperationCompleted;
        
        private System.Threading.SendOrPostCallback AddApplicationEventOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetHostsOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetUsersOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetApplicationsOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetEventsOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public MonitorWCFService() {
            this.Url = global::AppMonitorWPF.Properties.Settings.Default.AppMonitorWPF_WCF_Services_MonitorWCFService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event IsAliveCompletedEventHandler IsAliveCompleted;
        
        /// <remarks/>
        public event AddApplicationEventCompletedEventHandler AddApplicationEventCompleted;
        
        /// <remarks/>
        public event GetHostsCompletedEventHandler GetHostsCompleted;
        
        /// <remarks/>
        public event GetUsersCompletedEventHandler GetUsersCompleted;
        
        /// <remarks/>
        public event GetApplicationsCompletedEventHandler GetApplicationsCompleted;
        
        /// <remarks/>
        public event GetEventsCompletedEventHandler GetEventsCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IMonitorWCFService/IsAlive", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void IsAlive(out bool IsAliveResult, [System.Xml.Serialization.XmlIgnoreAttribute()] out bool IsAliveResultSpecified) {
            object[] results = this.Invoke("IsAlive", new object[0]);
            IsAliveResult = ((bool)(results[0]));
            IsAliveResultSpecified = ((bool)(results[1]));
        }
        
        /// <remarks/>
        public void IsAliveAsync() {
            this.IsAliveAsync(null);
        }
        
        /// <remarks/>
        public void IsAliveAsync(object userState) {
            if ((this.IsAliveOperationCompleted == null)) {
                this.IsAliveOperationCompleted = new System.Threading.SendOrPostCallback(this.OnIsAliveOperationCompleted);
            }
            this.InvokeAsync("IsAlive", new object[0], this.IsAliveOperationCompleted, userState);
        }
        
        private void OnIsAliveOperationCompleted(object arg) {
            if ((this.IsAliveCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.IsAliveCompleted(this, new IsAliveCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IMonitorWCFService/AddApplicationEvent", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void AddApplicationEvent([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string host, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string user, System.DateTime eventDateTime, [System.Xml.Serialization.XmlIgnoreAttribute()] bool eventDateTimeSpecified, MonitorWCFServiceAppState state, [System.Xml.Serialization.XmlIgnoreAttribute()] bool stateSpecified, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string guid, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string appTitle) {
            this.Invoke("AddApplicationEvent", new object[] {
                        host,
                        user,
                        eventDateTime,
                        eventDateTimeSpecified,
                        state,
                        stateSpecified,
                        guid,
                        appTitle});
        }
        
        /// <remarks/>
        public void AddApplicationEventAsync(string host, string user, System.DateTime eventDateTime, bool eventDateTimeSpecified, MonitorWCFServiceAppState state, bool stateSpecified, string guid, string appTitle) {
            this.AddApplicationEventAsync(host, user, eventDateTime, eventDateTimeSpecified, state, stateSpecified, guid, appTitle, null);
        }
        
        /// <remarks/>
        public void AddApplicationEventAsync(string host, string user, System.DateTime eventDateTime, bool eventDateTimeSpecified, MonitorWCFServiceAppState state, bool stateSpecified, string guid, string appTitle, object userState) {
            if ((this.AddApplicationEventOperationCompleted == null)) {
                this.AddApplicationEventOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAddApplicationEventOperationCompleted);
            }
            this.InvokeAsync("AddApplicationEvent", new object[] {
                        host,
                        user,
                        eventDateTime,
                        eventDateTimeSpecified,
                        state,
                        stateSpecified,
                        guid,
                        appTitle}, this.AddApplicationEventOperationCompleted, userState);
        }
        
        private void OnAddApplicationEventOperationCompleted(object arg) {
            if ((this.AddApplicationEventCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AddApplicationEventCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IMonitorWCFService/GetHosts", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute(IsNullable=true)]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(Namespace="http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
        public string[] GetHosts() {
            object[] results = this.Invoke("GetHosts", new object[0]);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public void GetHostsAsync() {
            this.GetHostsAsync(null);
        }
        
        /// <remarks/>
        public void GetHostsAsync(object userState) {
            if ((this.GetHostsOperationCompleted == null)) {
                this.GetHostsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetHostsOperationCompleted);
            }
            this.InvokeAsync("GetHosts", new object[0], this.GetHostsOperationCompleted, userState);
        }
        
        private void OnGetHostsOperationCompleted(object arg) {
            if ((this.GetHostsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetHostsCompleted(this, new GetHostsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IMonitorWCFService/GetUsers", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute(IsNullable=true)]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(Namespace="http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
        public string[] GetUsers([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string host) {
            object[] results = this.Invoke("GetUsers", new object[] {
                        host});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public void GetUsersAsync(string host) {
            this.GetUsersAsync(host, null);
        }
        
        /// <remarks/>
        public void GetUsersAsync(string host, object userState) {
            if ((this.GetUsersOperationCompleted == null)) {
                this.GetUsersOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetUsersOperationCompleted);
            }
            this.InvokeAsync("GetUsers", new object[] {
                        host}, this.GetUsersOperationCompleted, userState);
        }
        
        private void OnGetUsersOperationCompleted(object arg) {
            if ((this.GetUsersCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetUsersCompleted(this, new GetUsersCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IMonitorWCFService/GetApplications", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute(IsNullable=true)]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(Namespace="http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
        public string[] GetApplications([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string host, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string users) {
            object[] results = this.Invoke("GetApplications", new object[] {
                        host,
                        users});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public void GetApplicationsAsync(string host, string users) {
            this.GetApplicationsAsync(host, users, null);
        }
        
        /// <remarks/>
        public void GetApplicationsAsync(string host, string users, object userState) {
            if ((this.GetApplicationsOperationCompleted == null)) {
                this.GetApplicationsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetApplicationsOperationCompleted);
            }
            this.InvokeAsync("GetApplications", new object[] {
                        host,
                        users}, this.GetApplicationsOperationCompleted, userState);
        }
        
        private void OnGetApplicationsOperationCompleted(object arg) {
            if ((this.GetApplicationsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetApplicationsCompleted(this, new GetApplicationsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IMonitorWCFService/GetEvents", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute(IsNullable=true)]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(Namespace="http://schemas.datacontract.org/2004/07/AppMonitorWCFService")]
        public AppEvent[] GetEvents() {
            object[] results = this.Invoke("GetEvents", new object[0]);
            return ((AppEvent[])(results[0]));
        }
        
        /// <remarks/>
        public void GetEventsAsync() {
            this.GetEventsAsync(null);
        }
        
        /// <remarks/>
        public void GetEventsAsync(object userState) {
            if ((this.GetEventsOperationCompleted == null)) {
                this.GetEventsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetEventsOperationCompleted);
            }
            this.InvokeAsync("GetEvents", new object[0], this.GetEventsOperationCompleted, userState);
        }
        
        private void OnGetEventsOperationCompleted(object arg) {
            if ((this.GetEventsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetEventsCompleted(this, new GetEventsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName="MonitorWCFService.AppState", Namespace="http://schemas.datacontract.org/2004/07/AppMonitorWCFService")]
    public enum MonitorWCFServiceAppState {
        
        /// <remarks/>
        STARTED,
        
        /// <remarks/>
        CLOSED,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/AppMonitorWCFService")]
    public partial class AppEvent {
        
        private string appTitleField;
        
        private System.DateTime detectDTField;
        
        private bool detectDTFieldSpecified;
        
        private string guidField;
        
        private string hostField;
        
        private int idField;
        
        private bool idFieldSpecified;
        
        private System.Nullable<System.DateTime> isLostDTField;
        
        private bool isLostDTFieldSpecified;
        
        private string userField;
        
        private System.Nullable<long> workingTimeField;
        
        private bool workingTimeFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string AppTitle {
            get {
                return this.appTitleField;
            }
            set {
                this.appTitleField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime DetectDT {
            get {
                return this.detectDTField;
            }
            set {
                this.detectDTField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DetectDTSpecified {
            get {
                return this.detectDTFieldSpecified;
            }
            set {
                this.detectDTFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Guid {
            get {
                return this.guidField;
            }
            set {
                this.guidField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string Host {
            get {
                return this.hostField;
            }
            set {
                this.hostField = value;
            }
        }
        
        /// <remarks/>
        public int Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IdSpecified {
            get {
                return this.idFieldSpecified;
            }
            set {
                this.idFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> IsLostDT {
            get {
                return this.isLostDTField;
            }
            set {
                this.isLostDTField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsLostDTSpecified {
            get {
                return this.isLostDTFieldSpecified;
            }
            set {
                this.isLostDTFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string User {
            get {
                return this.userField;
            }
            set {
                this.userField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<long> WorkingTime {
            get {
                return this.workingTimeField;
            }
            set {
                this.workingTimeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool WorkingTimeSpecified {
            get {
                return this.workingTimeFieldSpecified;
            }
            set {
                this.workingTimeFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.81.0")]
    public delegate void IsAliveCompletedEventHandler(object sender, IsAliveCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.81.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class IsAliveCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal IsAliveCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool IsAliveResult {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public bool IsAliveResultSpecified {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[1]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.81.0")]
    public delegate void AddApplicationEventCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.81.0")]
    public delegate void GetHostsCompletedEventHandler(object sender, GetHostsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.81.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetHostsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetHostsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.81.0")]
    public delegate void GetUsersCompletedEventHandler(object sender, GetUsersCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.81.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetUsersCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetUsersCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.81.0")]
    public delegate void GetApplicationsCompletedEventHandler(object sender, GetApplicationsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.81.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetApplicationsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetApplicationsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.81.0")]
    public delegate void GetEventsCompletedEventHandler(object sender, GetEventsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.81.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetEventsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetEventsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public AppEvent[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((AppEvent[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591