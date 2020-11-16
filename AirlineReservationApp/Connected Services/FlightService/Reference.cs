﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AirlineReservationApp.FlightService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PlaneDetailDao", Namespace="http://schemas.datacontract.org/2004/07/Model")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(AirlineReservationApp.FlightService.FlightAndPlaneDetailDao))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(AirlineReservationApp.FlightService.FlightInfo))]
    public partial class PlaneDetailDao : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private short NoCol_EcoClassField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private short NoCol_FirstClassField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private short NoRow_EcoClassField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private short NoRow_FirstClassField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid PlaneIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PlaneTypeField;
        
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
        public short NoCol_EcoClass {
            get {
                return this.NoCol_EcoClassField;
            }
            set {
                if ((this.NoCol_EcoClassField.Equals(value) != true)) {
                    this.NoCol_EcoClassField = value;
                    this.RaisePropertyChanged("NoCol_EcoClass");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public short NoCol_FirstClass {
            get {
                return this.NoCol_FirstClassField;
            }
            set {
                if ((this.NoCol_FirstClassField.Equals(value) != true)) {
                    this.NoCol_FirstClassField = value;
                    this.RaisePropertyChanged("NoCol_FirstClass");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public short NoRow_EcoClass {
            get {
                return this.NoRow_EcoClassField;
            }
            set {
                if ((this.NoRow_EcoClassField.Equals(value) != true)) {
                    this.NoRow_EcoClassField = value;
                    this.RaisePropertyChanged("NoRow_EcoClass");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public short NoRow_FirstClass {
            get {
                return this.NoRow_FirstClassField;
            }
            set {
                if ((this.NoRow_FirstClassField.Equals(value) != true)) {
                    this.NoRow_FirstClassField = value;
                    this.RaisePropertyChanged("NoRow_FirstClass");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid PlaneId {
            get {
                return this.PlaneIdField;
            }
            set {
                if ((this.PlaneIdField.Equals(value) != true)) {
                    this.PlaneIdField = value;
                    this.RaisePropertyChanged("PlaneId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PlaneType {
            get {
                return this.PlaneTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.PlaneTypeField, value) != true)) {
                    this.PlaneTypeField = value;
                    this.RaisePropertyChanged("PlaneType");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FlightAndPlaneDetailDao", Namespace="http://schemas.datacontract.org/2004/07/Model")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(AirlineReservationApp.FlightService.FlightInfo))]
    public partial class FlightAndPlaneDetailDao : AirlineReservationApp.FlightService.PlaneDetailDao {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ArrivalAirportField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime ArrivalTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DepartureAirportField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DepartureTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> EcoClassCapacityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal EconomyClassPriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> FirstClassCapacityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal FirstClassPriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid FlightIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FlightNoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsAvailableField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ArrivalAirport {
            get {
                return this.ArrivalAirportField;
            }
            set {
                if ((object.ReferenceEquals(this.ArrivalAirportField, value) != true)) {
                    this.ArrivalAirportField = value;
                    this.RaisePropertyChanged("ArrivalAirport");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime ArrivalTime {
            get {
                return this.ArrivalTimeField;
            }
            set {
                if ((this.ArrivalTimeField.Equals(value) != true)) {
                    this.ArrivalTimeField = value;
                    this.RaisePropertyChanged("ArrivalTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DepartureAirport {
            get {
                return this.DepartureAirportField;
            }
            set {
                if ((object.ReferenceEquals(this.DepartureAirportField, value) != true)) {
                    this.DepartureAirportField = value;
                    this.RaisePropertyChanged("DepartureAirport");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime DepartureTime {
            get {
                return this.DepartureTimeField;
            }
            set {
                if ((this.DepartureTimeField.Equals(value) != true)) {
                    this.DepartureTimeField = value;
                    this.RaisePropertyChanged("DepartureTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> EcoClassCapacity {
            get {
                return this.EcoClassCapacityField;
            }
            set {
                if ((this.EcoClassCapacityField.Equals(value) != true)) {
                    this.EcoClassCapacityField = value;
                    this.RaisePropertyChanged("EcoClassCapacity");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal EconomyClassPrice {
            get {
                return this.EconomyClassPriceField;
            }
            set {
                if ((this.EconomyClassPriceField.Equals(value) != true)) {
                    this.EconomyClassPriceField = value;
                    this.RaisePropertyChanged("EconomyClassPrice");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> FirstClassCapacity {
            get {
                return this.FirstClassCapacityField;
            }
            set {
                if ((this.FirstClassCapacityField.Equals(value) != true)) {
                    this.FirstClassCapacityField = value;
                    this.RaisePropertyChanged("FirstClassCapacity");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal FirstClassPrice {
            get {
                return this.FirstClassPriceField;
            }
            set {
                if ((this.FirstClassPriceField.Equals(value) != true)) {
                    this.FirstClassPriceField = value;
                    this.RaisePropertyChanged("FirstClassPrice");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid FlightId {
            get {
                return this.FlightIdField;
            }
            set {
                if ((this.FlightIdField.Equals(value) != true)) {
                    this.FlightIdField = value;
                    this.RaisePropertyChanged("FlightId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FlightNo {
            get {
                return this.FlightNoField;
            }
            set {
                if ((object.ReferenceEquals(this.FlightNoField, value) != true)) {
                    this.FlightNoField = value;
                    this.RaisePropertyChanged("FlightNo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsAvailable {
            get {
                return this.IsAvailableField;
            }
            set {
                if ((this.IsAvailableField.Equals(value) != true)) {
                    this.IsAvailableField = value;
                    this.RaisePropertyChanged("IsAvailable");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FlightInfo", Namespace="http://schemas.datacontract.org/2004/07/Model")]
    [System.SerializableAttribute()]
    public partial class FlightInfo : AirlineReservationApp.FlightService.FlightAndPlaneDetailDao {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CalculatedEconomyClassCapacityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CalculatedFirstClassCapacityField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CalculatedEconomyClassCapacity {
            get {
                return this.CalculatedEconomyClassCapacityField;
            }
            set {
                if ((this.CalculatedEconomyClassCapacityField.Equals(value) != true)) {
                    this.CalculatedEconomyClassCapacityField = value;
                    this.RaisePropertyChanged("CalculatedEconomyClassCapacity");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CalculatedFirstClassCapacity {
            get {
                return this.CalculatedFirstClassCapacityField;
            }
            set {
                if ((this.CalculatedFirstClassCapacityField.Equals(value) != true)) {
                    this.CalculatedFirstClassCapacityField = value;
                    this.RaisePropertyChanged("CalculatedFirstClassCapacity");
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://AirplaneReservationLib", ConfigurationName="FlightService.IFlightService")]
    public interface IFlightService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://AirplaneReservationLib/IFlightService/InsertFlightInfo", ReplyAction="http://AirplaneReservationLib/IFlightService/InsertFlightInfoResponse")]
        bool InsertFlightInfo(AirlineReservationApp.FlightService.FlightInfo flightInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://AirplaneReservationLib/IFlightService/InsertFlightInfo", ReplyAction="http://AirplaneReservationLib/IFlightService/InsertFlightInfoResponse")]
        System.Threading.Tasks.Task<bool> InsertFlightInfoAsync(AirlineReservationApp.FlightService.FlightInfo flightInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://AirplaneReservationLib/IFlightService/RetrieveAllFlightInformation", ReplyAction="http://AirplaneReservationLib/IFlightService/RetrieveAllFlightInformationResponse" +
            "")]
        AirlineReservationApp.FlightService.FlightInfo[] RetrieveAllFlightInformation();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://AirplaneReservationLib/IFlightService/RetrieveAllFlightInformation", ReplyAction="http://AirplaneReservationLib/IFlightService/RetrieveAllFlightInformationResponse" +
            "")]
        System.Threading.Tasks.Task<AirlineReservationApp.FlightService.FlightInfo[]> RetrieveAllFlightInformationAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://AirplaneReservationLib/IFlightService/RetrieveAllPlaneInformation", ReplyAction="http://AirplaneReservationLib/IFlightService/RetrieveAllPlaneInformationResponse")]
        AirlineReservationApp.FlightService.PlaneDetailDao[] RetrieveAllPlaneInformation();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://AirplaneReservationLib/IFlightService/RetrieveAllPlaneInformation", ReplyAction="http://AirplaneReservationLib/IFlightService/RetrieveAllPlaneInformationResponse")]
        System.Threading.Tasks.Task<AirlineReservationApp.FlightService.PlaneDetailDao[]> RetrieveAllPlaneInformationAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://AirplaneReservationLib/IFlightService/RetrieveAvailableFlightInformation", ReplyAction="http://AirplaneReservationLib/IFlightService/RetrieveAvailableFlightInformationRe" +
            "sponse")]
        AirlineReservationApp.FlightService.FlightInfo[] RetrieveAvailableFlightInformation();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://AirplaneReservationLib/IFlightService/RetrieveAvailableFlightInformation", ReplyAction="http://AirplaneReservationLib/IFlightService/RetrieveAvailableFlightInformationRe" +
            "sponse")]
        System.Threading.Tasks.Task<AirlineReservationApp.FlightService.FlightInfo[]> RetrieveAvailableFlightInformationAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFlightServiceChannel : AirlineReservationApp.FlightService.IFlightService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FlightServiceClient : System.ServiceModel.ClientBase<AirlineReservationApp.FlightService.IFlightService>, AirlineReservationApp.FlightService.IFlightService {
        
        public FlightServiceClient() {
        }
        
        public FlightServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FlightServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FlightServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FlightServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool InsertFlightInfo(AirlineReservationApp.FlightService.FlightInfo flightInfo) {
            return base.Channel.InsertFlightInfo(flightInfo);
        }
        
        public System.Threading.Tasks.Task<bool> InsertFlightInfoAsync(AirlineReservationApp.FlightService.FlightInfo flightInfo) {
            return base.Channel.InsertFlightInfoAsync(flightInfo);
        }
        
        public AirlineReservationApp.FlightService.FlightInfo[] RetrieveAllFlightInformation() {
            return base.Channel.RetrieveAllFlightInformation();
        }
        
        public System.Threading.Tasks.Task<AirlineReservationApp.FlightService.FlightInfo[]> RetrieveAllFlightInformationAsync() {
            return base.Channel.RetrieveAllFlightInformationAsync();
        }
        
        public AirlineReservationApp.FlightService.PlaneDetailDao[] RetrieveAllPlaneInformation() {
            return base.Channel.RetrieveAllPlaneInformation();
        }
        
        public System.Threading.Tasks.Task<AirlineReservationApp.FlightService.PlaneDetailDao[]> RetrieveAllPlaneInformationAsync() {
            return base.Channel.RetrieveAllPlaneInformationAsync();
        }
        
        public AirlineReservationApp.FlightService.FlightInfo[] RetrieveAvailableFlightInformation() {
            return base.Channel.RetrieveAvailableFlightInformation();
        }
        
        public System.Threading.Tasks.Task<AirlineReservationApp.FlightService.FlightInfo[]> RetrieveAvailableFlightInformationAsync() {
            return base.Channel.RetrieveAvailableFlightInformationAsync();
        }
    }
}