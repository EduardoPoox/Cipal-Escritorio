﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace cipal.descargas.consultaestatus {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Acuse", Namespace="http://schemas.datacontract.org/2004/07/Sat.Cfdi.Negocio.ConsultaCfdi.Servicio")]
    [System.SerializableAttribute()]
    public partial class Acuse : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CodigoEstatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EsCancelableField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EstadoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EstatusCancelacionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ValidacionEFOSField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CodigoEstatus {
            get {
                return this.CodigoEstatusField;
            }
            set {
                if ((object.ReferenceEquals(this.CodigoEstatusField, value) != true)) {
                    this.CodigoEstatusField = value;
                    this.RaisePropertyChanged("CodigoEstatus");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EsCancelable {
            get {
                return this.EsCancelableField;
            }
            set {
                if ((object.ReferenceEquals(this.EsCancelableField, value) != true)) {
                    this.EsCancelableField = value;
                    this.RaisePropertyChanged("EsCancelable");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Estado {
            get {
                return this.EstadoField;
            }
            set {
                if ((object.ReferenceEquals(this.EstadoField, value) != true)) {
                    this.EstadoField = value;
                    this.RaisePropertyChanged("Estado");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EstatusCancelacion {
            get {
                return this.EstatusCancelacionField;
            }
            set {
                if ((object.ReferenceEquals(this.EstatusCancelacionField, value) != true)) {
                    this.EstatusCancelacionField = value;
                    this.RaisePropertyChanged("EstatusCancelacion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ValidacionEFOS {
            get {
                return this.ValidacionEFOSField;
            }
            set {
                if ((object.ReferenceEquals(this.ValidacionEFOSField, value) != true)) {
                    this.ValidacionEFOSField = value;
                    this.RaisePropertyChanged("ValidacionEFOS");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="consultaestatus.IConsultaCFDIService")]
    public interface IConsultaCFDIService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConsultaCFDIService/Consulta", ReplyAction="http://tempuri.org/IConsultaCFDIService/ConsultaResponse")]
        cipal.descargas.consultaestatus.Acuse Consulta(string expresionImpresa);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConsultaCFDIService/Consulta", ReplyAction="http://tempuri.org/IConsultaCFDIService/ConsultaResponse")]
        System.Threading.Tasks.Task<cipal.descargas.consultaestatus.Acuse> ConsultaAsync(string expresionImpresa);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IConsultaCFDIServiceChannel : cipal.descargas.consultaestatus.IConsultaCFDIService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ConsultaCFDIServiceClient : System.ServiceModel.ClientBase<cipal.descargas.consultaestatus.IConsultaCFDIService>, cipal.descargas.consultaestatus.IConsultaCFDIService {
        
        public ConsultaCFDIServiceClient() {
        }
        
        public ConsultaCFDIServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ConsultaCFDIServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ConsultaCFDIServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ConsultaCFDIServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public cipal.descargas.consultaestatus.Acuse Consulta(string expresionImpresa) {
            return base.Channel.Consulta(expresionImpresa);
        }
        
        public System.Threading.Tasks.Task<cipal.descargas.consultaestatus.Acuse> ConsultaAsync(string expresionImpresa) {
            return base.Channel.ConsultaAsync(expresionImpresa);
        }
    }
}
