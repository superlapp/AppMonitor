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

namespace AppMonitorWPF.localhost {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="BasicHttpBinding_IMonitorWCFService", Namespace="http://tempuri.org/")]
    public partial class MonitorWCFService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetStatusOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetRequestsOperationCompleted;
        
        private System.Threading.SendOrPostCallback ApplicationFoundOperationCompleted;
        
        private System.Threading.SendOrPostCallback ApplicationIsLostOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetHostsOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetUsersOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetApplicationsOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public MonitorWCFService() {
            this.Url = global::AppMonitorWPF.Properties.Settings.Default.AppMonitorWPF_localhost_MonitorWCFService;
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
        public event GetStatusCompletedEventHandler GetStatusCompleted;
        
        /// <remarks/>
        public event GetRequestsCompletedEventHandler GetRequestsCompleted;
        
        /// <remarks/>
        public event ApplicationFoundCompletedEventHandler ApplicationFoundCompleted;
        
        /// <remarks/>
        public event ApplicationIsLostCompletedEventHandler ApplicationIsLostCompleted;
        
        /// <remarks/>
        public event GetHostsCompletedEventHandler GetHostsCompleted;
        
        /// <remarks/>
        public event GetUsersCompletedEventHandler GetUsersCompleted;
        
        /// <remarks/>
        public event GetApplicationsCompletedEventHandler GetApplicationsCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IMonitorWCFService/GetStatus", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string GetStatus() {
            object[] results = this.Invoke("GetStatus", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetStatusAsync() {
            this.GetStatusAsync(null);
        }
        
        /// <remarks/>
        public void GetStatusAsync(object userState) {
            if ((this.GetStatusOperationCompleted == null)) {
                this.GetStatusOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetStatusOperationCompleted);
            }
            this.InvokeAsync("GetStatus", new object[0], this.GetStatusOperationCompleted, userState);
        }
        
        private void OnGetStatusOperationCompleted(object arg) {
            if ((this.GetStatusCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetStatusCompleted(this, new GetStatusCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IMonitorWCFService/GetRequests", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute(IsNullable=true)]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(Namespace="http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
        public string[] GetRequests() {
            object[] results = this.Invoke("GetRequests", new object[0]);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public void GetRequestsAsync() {
            this.GetRequestsAsync(null);
        }
        
        /// <remarks/>
        public void GetRequestsAsync(object userState) {
            if ((this.GetRequestsOperationCompleted == null)) {
                this.GetRequestsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetRequestsOperationCompleted);
            }
            this.InvokeAsync("GetRequests", new object[0], this.GetRequestsOperationCompleted, userState);
        }
        
        private void OnGetRequestsOperationCompleted(object arg) {
            if ((this.GetRequestsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetRequestsCompleted(this, new GetRequestsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IMonitorWCFService/ApplicationFound", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void ApplicationFound([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string host, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string user, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string app, System.DateTime datetime, [System.Xml.Serialization.XmlIgnoreAttribute()] bool datetimeSpecified) {
            this.Invoke("ApplicationFound", new object[] {
                        host,
                        user,
                        app,
                        datetime,
                        datetimeSpecified});
        }
        
        /// <remarks/>
        public void ApplicationFoundAsync(string host, string user, string app, System.DateTime datetime, bool datetimeSpecified) {
            this.ApplicationFoundAsync(host, user, app, datetime, datetimeSpecified, null);
        }
        
        /// <remarks/>
        public void ApplicationFoundAsync(string host, string user, string app, System.DateTime datetime, bool datetimeSpecified, object userState) {
            if ((this.ApplicationFoundOperationCompleted == null)) {
                this.ApplicationFoundOperationCompleted = new System.Threading.SendOrPostCallback(this.OnApplicationFoundOperationCompleted);
            }
            this.InvokeAsync("ApplicationFound", new object[] {
                        host,
                        user,
                        app,
                        datetime,
                        datetimeSpecified}, this.ApplicationFoundOperationCompleted, userState);
        }
        
        private void OnApplicationFoundOperationCompleted(object arg) {
            if ((this.ApplicationFoundCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ApplicationFoundCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IMonitorWCFService/ApplicationIsLost", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void ApplicationIsLost([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string host, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string user, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string app, System.DateTime datetime, [System.Xml.Serialization.XmlIgnoreAttribute()] bool datetimeSpecified) {
            this.Invoke("ApplicationIsLost", new object[] {
                        host,
                        user,
                        app,
                        datetime,
                        datetimeSpecified});
        }
        
        /// <remarks/>
        public void ApplicationIsLostAsync(string host, string user, string app, System.DateTime datetime, bool datetimeSpecified) {
            this.ApplicationIsLostAsync(host, user, app, datetime, datetimeSpecified, null);
        }
        
        /// <remarks/>
        public void ApplicationIsLostAsync(string host, string user, string app, System.DateTime datetime, bool datetimeSpecified, object userState) {
            if ((this.ApplicationIsLostOperationCompleted == null)) {
                this.ApplicationIsLostOperationCompleted = new System.Threading.SendOrPostCallback(this.OnApplicationIsLostOperationCompleted);
            }
            this.InvokeAsync("ApplicationIsLost", new object[] {
                        host,
                        user,
                        app,
                        datetime,
                        datetimeSpecified}, this.ApplicationIsLostOperationCompleted, userState);
        }
        
        private void OnApplicationIsLostOperationCompleted(object arg) {
            if ((this.ApplicationIsLostCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ApplicationIsLostCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void GetStatusCompletedEventHandler(object sender, GetStatusCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetStatusCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetStatusCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void GetRequestsCompletedEventHandler(object sender, GetRequestsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetRequestsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetRequestsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void ApplicationFoundCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void ApplicationIsLostCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void GetHostsCompletedEventHandler(object sender, GetHostsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void GetUsersCompletedEventHandler(object sender, GetUsersCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void GetApplicationsCompletedEventHandler(object sender, GetApplicationsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
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
}

#pragma warning restore 1591