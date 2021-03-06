
    using System;
    using System.Collections.Generic;
    using CprBroker.Schemas.Wrappers;
  
    namespace CprBroker.Providers.CPRDirect
    {
    
    public partial class IndividualRequestType: Wrapper
    {
        #region Common

        public override int Length
        {
            get { return 39; }
        }
        #endregion

        #region Properties

        ///  <summary>
        /// CPR's transaction code
        ///  </summary>
        public string CPRTRANS
        {
            get { return this.GetString(1, 4); }
            set { this.SetString(value, 1, 4); }
        }
        ///  <summary>
        /// Danish: KOMMA
        /// Comma character used as separator
        ///  </summary>
        public char Comma
        {
            get { return this.GetChar(5); }
            set { this.SetChar(value, 5); }
        }
        ///  <summary>
        /// Danish: KUNDENR
        /// Identification of the customer
        ///  </summary>
        public decimal CustomerNumber
        {
            get { return this.GetDecimal(6, 4); }
            set { this.SetDecimal(value, 6, 4); }
        }
        ///  <summary>
        /// Danish: ABON_TYPE
        /// Subscription phrase / delete or not
        ///  </summary>
        public decimal SubscriptionType
        {
            get { return this.GetDecimal(10, 1); }
            set { this.SetDecimal(value, 10, 1); }
        }
        ///  <summary>
        /// Danish: DATA_TYPE
        /// Desired output - 0 in LOGONINDIVID
        ///  </summary>
        public decimal DataType
        {
            get { return this.GetDecimal(11, 1); }
            set { this.SetDecimal(value, 11, 1); }
        }
        ///  <summary>
        /// Danish: TOKEN
        ///  </summary>
        public string Token
        {
            get { return this.GetString(12, 8); }
            set { this.SetString(value, 12, 8); }
        }
        ///  <summary>
        /// Danish: BRUGER_ID
        /// The CPR Unit assigned system user code
        ///  </summary>
        public string UserId
        {
            get { return this.GetString(20, 8); }
            set { this.SetString(value, 20, 8); }
        }
        ///  <summary>
        /// Danish: FEJLNR
        /// Indicator of the communication process
        ///  </summary>
        public decimal ErrorNumber
        {
            get { return this.GetDecimal(28, 2); }
            set { this.SetDecimal(value, 28, 2); }
        }
        ///  <summary>
        /// Danish: PNR
        /// Request PNR
        ///  </summary>
        public decimal PNR
        {
            get { return this.GetDecimal(30, 10); }
            set { this.SetDecimal(value, 30, 10); }
        }

        #endregion

    }

  
    public partial class IndividualResponseType: CompositeWrapper
    {
        #region Common

        public override int Length
        {
            get { return 0; }
        }
        #endregion

        #region Properties

        ///  <summary>
        /// Danish: KUNDENR
        /// Identification of the customer
        ///  </summary>
        public decimal CustomerNumber
        {
            get { return this.GetDecimal(1, 4); }
            set { this.SetDecimal(value, 1, 4); }
        }
        ///  <summary>
        /// Danish: ABON_TYPE
        /// Subscription phrase / delete or not
        ///  </summary>
        public decimal SubscriptionType
        {
            get { return this.GetDecimal(5, 1); }
            set { this.SetDecimal(value, 5, 1); }
        }
        ///  <summary>
        /// Danish: DATA_TYPE
        /// 0 in LOGONINDIVID (see Annex 2)Desired output
        ///  </summary>
        public decimal DataType
        {
            get { return this.GetDecimal(6, 1); }
            set { this.SetDecimal(value, 6, 1); }
        }
        ///  <summary>
        /// Danish: TOKEN
        /// Taken from the logon
        ///  </summary>
        public string Token
        {
            get { return this.GetString(7, 8); }
            set { this.SetString(value, 7, 8); }
        }
        ///  <summary>
        /// Danish: BRUGER-ID
        /// The CPR Unit assigned system user code
        ///  </summary>
        public string UserId
        {
            get { return this.GetString(15, 8); }
            set { this.SetString(value, 15, 8); }
        }
        ///  <summary>
        /// Danish: FEJLNR
        /// Indicator of the communication process
        ///  </summary>
        public decimal ErrorNumber
        {
            get { return this.GetDecimal(23, 2); }
            set { this.SetDecimal(value, 23, 2); }
        }
        ///  <summary>
        /// Length of structure 28 + data MAX 2880
        ///  </summary>
        public decimal DataLength
        {
            get { return this.GetDecimal(25, 4); }
            set { this.SetDecimal(value, 25, 4); }
        }
        ///  <summary>
        /// Danish: DATA
        /// Personal data from the CPR (format and amount depends on DATA_TYPE
        ///  </summary>
        public string Data
        {
            get { return this.GetString(29, 2880); }
            set { this.SetString(value, 29, 2880); }
        }

        #endregion

        #region Sub objects
        
        private StartRecordType _StartRecord = null;

        [MinMaxOccurs(MinOccurs = 1, MaxOccurs = 1)]
        public StartRecordType StartRecord
        {
            get { return _StartRecord; }
            set { _StartRecord = value; }
        }

        private PersonInformationType _PersonInformation = null;

        [MinMaxOccurs(MinOccurs = 1, MaxOccurs = 1)]
        public PersonInformationType PersonInformation
        {
            get { return _PersonInformation; }
            set { _PersonInformation = value; }
        }

        private CurrentAddressInformationType _CurrentAddressInformation = null;

        [MinMaxOccurs(MinOccurs = 0, MaxOccurs = 1)]
        public CurrentAddressInformationType CurrentAddressInformation
        {
            get { return _CurrentAddressInformation; }
            set { _CurrentAddressInformation = value; }
        }

        private ClearWrittenAddressType _ClearWrittenAddress = null;

        [MinMaxOccurs(MinOccurs = 1, MaxOccurs = 1)]
        public ClearWrittenAddressType ClearWrittenAddress
        {
            get { return _ClearWrittenAddress; }
            set { _ClearWrittenAddress = value; }
        }

        private List<ProtectionType> _Protection = new List<ProtectionType>();

        [MinMaxOccurs(MinOccurs = 0, MaxOccurs = 4)]
        public List<ProtectionType> Protection
        {
            get { return _Protection; }
            set { _Protection = value; }
        }

        private CurrentDepartureDataType _CurrentDepartureData = null;

        [MinMaxOccurs(MinOccurs = 0, MaxOccurs = 1)]
        public CurrentDepartureDataType CurrentDepartureData
        {
            get { return _CurrentDepartureData; }
            set { _CurrentDepartureData = value; }
        }

        private ContactAddressType _ContactAddress = null;

        [MinMaxOccurs(MinOccurs = 0, MaxOccurs = 1)]
        public ContactAddressType ContactAddress
        {
            get { return _ContactAddress; }
            set { _ContactAddress = value; }
        }

        private CurrentDisappearanceInformationType _CurrentDisappearanceInformation = null;

        [MinMaxOccurs(MinOccurs = 0, MaxOccurs = 1)]
        public CurrentDisappearanceInformationType CurrentDisappearanceInformation
        {
            get { return _CurrentDisappearanceInformation; }
            set { _CurrentDisappearanceInformation = value; }
        }

        private CurrentNameInformationType _CurrentNameInformation = null;

        [MinMaxOccurs(MinOccurs = 1, MaxOccurs = 1)]
        public CurrentNameInformationType CurrentNameInformation
        {
            get { return _CurrentNameInformation; }
            set { _CurrentNameInformation = value; }
        }

        private BirthRegistrationInformationType _BirthRegistrationInformation = null;

        [MinMaxOccurs(MinOccurs = 1, MaxOccurs = 1)]
        public BirthRegistrationInformationType BirthRegistrationInformation
        {
            get { return _BirthRegistrationInformation; }
            set { _BirthRegistrationInformation = value; }
        }

        private CurrentCitizenshipType _CurrentCitizenship = null;

        [MinMaxOccurs(MinOccurs = 1, MaxOccurs = 1)]
        public CurrentCitizenshipType CurrentCitizenship
        {
            get { return _CurrentCitizenship; }
            set { _CurrentCitizenship = value; }
        }

        private ChurchInformationType _ChurchInformation = null;

        [MinMaxOccurs(MinOccurs = 1, MaxOccurs = 1)]
        public ChurchInformationType ChurchInformation
        {
            get { return _ChurchInformation; }
            set { _ChurchInformation = value; }
        }

        private CurrentCivilStatusType _CurrentCivilStatus = null;

        [MinMaxOccurs(MinOccurs = 1, MaxOccurs = 1)]
        public CurrentCivilStatusType CurrentCivilStatus
        {
            get { return _CurrentCivilStatus; }
            set { _CurrentCivilStatus = value; }
        }

        private CurrentSeparationType _CurrentSeparation = null;

        [MinMaxOccurs(MinOccurs = 0, MaxOccurs = 1)]
        public CurrentSeparationType CurrentSeparation
        {
            get { return _CurrentSeparation; }
            set { _CurrentSeparation = value; }
        }

        private List<ChildType> _Child = new List<ChildType>();

        [MinMaxOccurs(MinOccurs = 0, MaxOccurs = 25)]
        public List<ChildType> Child
        {
            get { return _Child; }
            set { _Child = value; }
        }

        private ParentsInformationType _ParentsInformation = null;

        [MinMaxOccurs(MinOccurs = 1, MaxOccurs = 1)]
        public ParentsInformationType ParentsInformation
        {
            get { return _ParentsInformation; }
            set { _ParentsInformation = value; }
        }

        private List<ParentalAuthorityType> _ParentalAuthority = new List<ParentalAuthorityType>();

        [MinMaxOccurs(MinOccurs = 0, MaxOccurs = 2)]
        public List<ParentalAuthorityType> ParentalAuthority
        {
            get { return _ParentalAuthority; }
            set { _ParentalAuthority = value; }
        }

        private DisempowermentType _Disempowerment = null;

        [MinMaxOccurs(MinOccurs = 0, MaxOccurs = 1)]
        public DisempowermentType Disempowerment
        {
            get { return _Disempowerment; }
            set { _Disempowerment = value; }
        }

        private List<MunicipalConditionsType> _MunicipalConditions = new List<MunicipalConditionsType>();

        [MinMaxOccurs(MinOccurs = 0, MaxOccurs = 1000000)]
        public List<MunicipalConditionsType> MunicipalConditions
        {
            get { return _MunicipalConditions; }
            set { _MunicipalConditions = value; }
        }

        private List<NotesType> _Notes = new List<NotesType>();

        [MinMaxOccurs(MinOccurs = 0, MaxOccurs = 1000000)]
        public List<NotesType> Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }

        private List<ElectionInformationType> _ElectionInformation = new List<ElectionInformationType>();

        [MinMaxOccurs(MinOccurs = 0, MaxOccurs = 1000000)]
        public List<ElectionInformationType> ElectionInformation
        {
            get { return _ElectionInformation; }
            set { _ElectionInformation = value; }
        }

        private RelocationOrderType _RelocationOrder = null;

        [MinMaxOccurs(MinOccurs = 0, MaxOccurs = 1)]
        public RelocationOrderType RelocationOrder
        {
            get { return _RelocationOrder; }
            set { _RelocationOrder = value; }
        }

        private List<HistoricalPNRType> _HistoricalPNR = new List<HistoricalPNRType>();

        [MinMaxOccurs(MinOccurs = 0, MaxOccurs = 1000000)]
        public List<HistoricalPNRType> HistoricalPNR
        {
            get { return _HistoricalPNR; }
            set { _HistoricalPNR = value; }
        }

        private List<HistoricalAddressType> _HistoricalAddress = new List<HistoricalAddressType>();

        [MinMaxOccurs(MinOccurs = 0, MaxOccurs = 1000)]
        public List<HistoricalAddressType> HistoricalAddress
        {
            get { return _HistoricalAddress; }
            set { _HistoricalAddress = value; }
        }

        private List<HistoricalDepartureType> _HistoricalDeparture = new List<HistoricalDepartureType>();

        [MinMaxOccurs(MinOccurs = 0, MaxOccurs = 1000000)]
        public List<HistoricalDepartureType> HistoricalDeparture
        {
            get { return _HistoricalDeparture; }
            set { _HistoricalDeparture = value; }
        }

        private List<HistoricalDisappearanceType> _HistoricalDisappearance = new List<HistoricalDisappearanceType>();

        [MinMaxOccurs(MinOccurs = 0, MaxOccurs = 1000000)]
        public List<HistoricalDisappearanceType> HistoricalDisappearance
        {
            get { return _HistoricalDisappearance; }
            set { _HistoricalDisappearance = value; }
        }

        private List<HistoricalNameType> _HistoricalName = new List<HistoricalNameType>();

        [MinMaxOccurs(MinOccurs = 0, MaxOccurs = 1000000)]
        public List<HistoricalNameType> HistoricalName
        {
            get { return _HistoricalName; }
            set { _HistoricalName = value; }
        }

        private List<HistoricalCitizenshipType> _HistoricalCitizenship = new List<HistoricalCitizenshipType>();

        [MinMaxOccurs(MinOccurs = 0, MaxOccurs = 1000000)]
        public List<HistoricalCitizenshipType> HistoricalCitizenship
        {
            get { return _HistoricalCitizenship; }
            set { _HistoricalCitizenship = value; }
        }

        private List<HistoricalChurchInformationType> _HistoricalChurchInformation = new List<HistoricalChurchInformationType>();

        [MinMaxOccurs(MinOccurs = 0, MaxOccurs = 1000000)]
        public List<HistoricalChurchInformationType> HistoricalChurchInformation
        {
            get { return _HistoricalChurchInformation; }
            set { _HistoricalChurchInformation = value; }
        }

        private List<HistoricalCivilStatusType> _HistoricalCivilStatus = new List<HistoricalCivilStatusType>();

        [MinMaxOccurs(MinOccurs = 0, MaxOccurs = 1000000)]
        public List<HistoricalCivilStatusType> HistoricalCivilStatus
        {
            get { return _HistoricalCivilStatus; }
            set { _HistoricalCivilStatus = value; }
        }

        private List<HistoricalSeparationType> _HistoricalSeparation = new List<HistoricalSeparationType>();

        [MinMaxOccurs(MinOccurs = 0, MaxOccurs = 1000000)]
        public List<HistoricalSeparationType> HistoricalSeparation
        {
            get { return _HistoricalSeparation; }
            set { _HistoricalSeparation = value; }
        }

        private List<EventsType> _Events = new List<EventsType>();

        [MinMaxOccurs(MinOccurs = 0, MaxOccurs = 1000000)]
        public List<EventsType> Events
        {
            get { return _Events; }
            set { _Events = value; }
        }

        private List<ErrorRecordType> _ErrorRecord = new List<ErrorRecordType>();

        [MinMaxOccurs(MinOccurs = 0, MaxOccurs = 1000000)]
        public List<ErrorRecordType> ErrorRecord
        {
            get { return _ErrorRecord; }
            set { _ErrorRecord = value; }
        }

        private List<SubscriptionDeletionReceiptType> _SubscriptionDeletionReceipt = new List<SubscriptionDeletionReceiptType>();

        [MinMaxOccurs(MinOccurs = 0, MaxOccurs = 1000000)]
        public List<SubscriptionDeletionReceiptType> SubscriptionDeletionReceipt
        {
            get { return _SubscriptionDeletionReceipt; }
            set { _SubscriptionDeletionReceipt = value; }
        }

        private EndRecordType _EndRecord = null;

        [MinMaxOccurs(MinOccurs = 1, MaxOccurs = 1)]
        public EndRecordType EndRecord
        {
            get { return _EndRecord; }
            set { _EndRecord = value; }
        }


        #endregion

    }

  
    public partial class StartRecordType: Wrapper
    {
        #region Common

        public override int Length
        {
            get { return 35; }
        }
        #endregion

        #region Properties

        ///  <summary>
        /// Danish: RECORDTYPE
        /// Equals last three digits of the record name
        ///  </summary>
        public decimal RecordType
        {
            get { return this.GetDecimal(1, 3); }
            set { this.SetDecimal(value, 1, 3); }
        }
        ///  <summary>
        /// Danish: SORTFELT-10
        /// BLACK BOX-10
        ///  </summary>
        public string BlackBox10
        {
            get { return this.GetString(4, 10); }
            set { this.SetString(value, 4, 10); }
        }
        ///  <summary>
        /// Danish: OPGAVENR
        ///  </summary>
        public decimal TaskNumber
        {
            get { return this.GetDecimal(14, 6); }
            set { this.SetDecimal(value, 14, 6); }
        }
        ///  <summary>
        /// Danish: PRODDTO
        /// Production date yyyyMMdd
        ///  </summary>
        public DateTime? ProductionDate
        {
            get { return this.GetDateTime(20, 8, "yyyyMMdd"); }
            set { this.SetDateTime(value, 20, 8, "yyyyMMdd"); }
        }
        ///  <summary>
        /// Danish: PRODDTOFORRIG
        /// Previous production date yyyyMMdd
        ///  </summary>
        public DateTime? PreviousProductionDate
        {
            get { return this.GetDateTime(28, 8, "yyyyMMdd"); }
            set { this.SetDateTime(value, 28, 8, "yyyyMMdd"); }
        }

        #endregion

    }

  
    public partial class PersonInformationType: PersonRecordWrapper
    {
        #region Common

        public override int Length
        {
            get { return 106; }
        }
        #endregion

        #region Properties

        ///  <summary>
        /// Danish: RECORDTYPE
        /// Equals last three digits of the record name
        ///  </summary>
        public decimal RecordType
        {
            get { return this.GetDecimal(1, 3); }
            set { this.SetDecimal(value, 1, 3); }
        }
        ///  <summary>
        /// Danish: PNR
        /// CPR Number
        ///  </summary>
        public string PNR
        {
            get { return this.GetString(4, 10); }
            set { this.SetString(value, 4, 10); }
        }
        ///  <summary>
        /// Danish: PNRGAELD
        /// Current CPR Number
        ///  </summary>
        public string CurrentCprNumber
        {
            get { return this.GetString(14, 10); }
            set { this.SetString(value, 14, 10); }
        }
        ///  <summary>
        /// Danish: STATUS
        /// Status
        ///  </summary>
        public decimal Status
        {
            get { return this.GetDecimal(24, 2); }
            set { this.SetDecimal(value, 24, 2); }
        }
        ///  <summary>
        /// Danish: STATUSHAENSTART
        /// Status date yyyyMMddHHmm
        ///  </summary>
        public DateTime? StatusStartDate
        {
            get { return this.GetDateTime(26, 12, "yyyyMMddHHmm"); }
            set { this.SetDateTime(value, 26, 12, "yyyyMMddHHmm"); }
        }
        ///  <summary>
        /// Danish: STATUSDTO_UMRK
        /// Status date uncertainty marker
        ///  </summary>
        public char StatusDateUncertainty
        {
            get { return this.GetChar(38); }
            set { this.SetChar(value, 38); }
        }
        ///  <summary>
        /// Danish: KOEN
        /// CPR Number
        ///  </summary>
        public char Gender
        {
            get { return this.GetChar(39); }
            set { this.SetChar(value, 39); }
        }
        ///  <summary>
        /// Danish: FOED_DT
        /// Birth date yyyy-MM-dd
        ///  </summary>
        public DateTime? Birthdate
        {
            get { return this.GetDateTime(40, 10, "yyyy-MM-dd"); }
            set { this.SetDateTime(value, 40, 10, "yyyy-MM-dd"); }
        }
        ///  <summary>
        /// Danish: FOED_DT_UMRK
        /// Birth date uncertainty marker
        ///  </summary>
        public char BirthdateUncertainty
        {
            get { return this.GetChar(50); }
            set { this.SetChar(value, 50); }
        }
        ///  <summary>
        /// Danish: START_DT-PERSON
        /// Person start date yyyy-MM-dd
        ///  </summary>
        public DateTime? PersonStartDate
        {
            get { return this.GetDateTime(51, 10, "yyyy-MM-dd"); }
            set { this.SetDateTime(value, 51, 10, "yyyy-MM-dd"); }
        }
        ///  <summary>
        /// Danish: START_DT_UMRK-PERSON
        /// Start date uncertainty marker
        ///  </summary>
        public char PersonStartDateUncertainty
        {
            get { return this.GetChar(61); }
            set { this.SetChar(value, 61); }
        }
        ///  <summary>
        /// Danish: SLUT_DT-PERSON
        /// Person end date yyyy-MM-dd
        ///  </summary>
        public DateTime? PersonEndDate 
        {
            get { return this.GetDateTime(62, 10, "yyyy-MM-dd"); }
            set { this.SetDateTime(value, 62, 10, "yyyy-MM-dd"); }
        }
        ///  <summary>
        /// Danish: PNR
        /// End date uncertainty marker
        ///  </summary>
        public char PersonEndDateUncertainty
        {
            get { return this.GetChar(72); }
            set { this.SetChar(value, 72); }
        }
        ///  <summary>
        /// Danish: STILLING
        /// Job
        ///  </summary>
        public string Job
        {
            get { return this.GetString(73, 34); }
            set { this.SetString(value, 73, 34); }
        }

        #endregion

    }

  
    public partial class CurrentAddressInformationType: PersonRecordWrapper
    {
        #region Common

        public override int Length
        {
            get { return 306; }
        }
        #endregion

        #region Properties

        ///  <summary>
        /// Danish: RECORDTYPE
        /// Equals last three digits of the record name
        ///  </summary>
        public decimal RecordType
        {
            get { return this.GetDecimal(1, 3); }
            set { this.SetDecimal(value, 1, 3); }
        }
        ///  <summary>
        /// Danish: PNR
        /// CPR Number
        ///  </summary>
        public string PNR
        {
            get { return this.GetString(4, 10); }
            set { this.SetString(value, 4, 10); }
        }
        ///  <summary>
        /// Danish: KOMKOD
        /// Municipality
        ///  </summary>
        public decimal MunicipalityCode
        {
            get { return this.GetDecimal(14, 4); }
            set { this.SetDecimal(value, 14, 4); }
        }
        ///  <summary>
        /// Danish: VEJKOD
        /// Street
        ///  </summary>
        public decimal StreetCode
        {
            get { return this.GetDecimal(18, 4); }
            set { this.SetDecimal(value, 18, 4); }
        }
        ///  <summary>
        /// Danish: HUSNR
        /// House
        ///  </summary>
        public string HouseNumber
        {
            get { return this.GetString(22, 4); }
            set { this.SetString(value, 22, 4); }
        }
        ///  <summary>
        /// Danish: ETAGE
        /// Floor
        ///  </summary>
        public string Floor
        {
            get { return this.GetString(26, 2); }
            set { this.SetString(value, 26, 2); }
        }
        ///  <summary>
        /// Danish: SIDEDOER
        /// Door
        ///  </summary>
        public string Door
        {
            get { return this.GetString(28, 4); }
            set { this.SetString(value, 28, 4); }
        }
        ///  <summary>
        /// Danish: BNR
        /// Building number
        ///  </summary>
        public string BuildingNumber
        {
            get { return this.GetString(32, 4); }
            set { this.SetString(value, 32, 4); }
        }
        ///  <summary>
        /// Danish: CONVN
        /// C/O name
        ///  </summary>
        public string CareOfName
        {
            get { return this.GetString(36, 34); }
            set { this.SetString(value, 36, 34); }
        }
        ///  <summary>
        /// Danish: TILFLYDTO
        /// Relocation date yyyyMMddTTMM
        ///  </summary>
        public DateTime? RelocationDate
        {
            get { return this.GetDateTime(70, 12, "yyyyMMddHHmm"); }
            set { this.SetDateTime(value, 70, 12, "yyyyMMddHHmm"); }
        }
        ///  <summary>
        /// Danish: TILFLYDT_UMRK
        /// Relocation date uncertainty marker
        ///  </summary>
        public char RelocationDateUncertainty
        {
            get { return this.GetChar(82); }
            set { this.SetChar(value, 82); }
        }
        ///  <summary>
        /// Danish: TILFLYKOMDTO
        /// Municipality arrival date yyyyMMddTTMM
        ///  </summary>
        public DateTime? MunicipalityArrivalDate
        {
            get { return this.GetDateTime(83, 12, "yyyyMMddHHmm"); }
            set { this.SetDateTime(value, 83, 12, "yyyyMMddHHmm"); }
        }
        ///  <summary>
        /// Danish: TILFLYKOMDT_UMRK
        /// Municipality arrival date uncertainty marker
        ///  </summary>
        public char MunicipalityArrivalDateUncertainty
        {
            get { return this.GetChar(95); }
            set { this.SetChar(value, 95); }
        }
        ///  <summary>
        /// Danish: FRAFLYKOMKOD
        /// Leaving municipality code
        ///  </summary>
        public decimal LeavingMunicipalityCode
        {
            get { return this.GetDecimal(96, 4); }
            set { this.SetDecimal(value, 96, 4); }
        }
        ///  <summary>
        /// Danish: FRAFLYKOMDTO
        /// Leaving previous municipality departure date yyyyMMddTTMM
        ///  </summary>
        public DateTime? LeavingMunicipalityDepartureDate
        {
            get { return this.GetDateTime(100, 12, "yyyyMMddHHmm"); }
            set { this.SetDateTime(value, 100, 12, "yyyyMMddHHmm"); }
        }
        ///  <summary>
        /// Danish: FRAFLYKOMDT_UMRK
        /// Leaving previous municipality departure date uncertainty
        ///  </summary>
        public char LeavingMunicipalityDepartureDateUncertainty
        {
            get { return this.GetChar(112); }
            set { this.SetChar(value, 112); }
        }
        ///  <summary>
        /// Danish: START_MYNKOD-ADRTXT
        /// HomeAuthority
        ///  </summary>
        public decimal HomeAuthority
        {
            get { return this.GetDecimal(113, 4); }
            set { this.SetDecimal(value, 113, 4); }
        }
        ///  <summary>
        /// Danish: ADR1-SUPLADR
        /// First line of supplementary address
        ///  </summary>
        public string SupplementaryAddress1
        {
            get { return this.GetString(117, 34); }
            set { this.SetString(value, 117, 34); }
        }
        ///  <summary>
        /// Danish: ADR2-SUPLADR
        /// Second line of supplementary address
        ///  </summary>
        public string SupplementaryAddress2
        {
            get { return this.GetString(151, 34); }
            set { this.SetString(value, 151, 34); }
        }
        ///  <summary>
        /// Danish: ADR3-SUPLADR
        /// Third line of supplementary address
        ///  </summary>
        public string SupplementaryAddress3
        {
            get { return this.GetString(185, 34); }
            set { this.SetString(value, 185, 34); }
        }
        ///  <summary>
        /// Danish: ADR4-SUPLADR
        /// Fourth line of supplementary address
        ///  </summary>
        public string SupplementaryAddress4
        {
            get { return this.GetString(219, 34); }
            set { this.SetString(value, 219, 34); }
        }
        ///  <summary>
        /// Danish: ADR5-SUPLADR
        /// Fifth line of supplementary address
        ///  </summary>
        public string SupplementaryAddress5
        {
            get { return this.GetString(253, 34); }
            set { this.SetString(value, 253, 34); }
        }
        ///  <summary>
        /// Danish: START_DT-ADRTXT
        /// Start date yyyy-MM-dd
        ///  </summary>
        public DateTime? StartDate
        {
            get { return this.GetDateTime(287, 10, "yyyy-MM-dd"); }
            set { this.SetDateTime(value, 287, 10, "yyyy-MM-dd"); }
        }
        ///  <summary>
        /// Danish: SLET_DT-ADRTXT
        /// End date yyyy-MM-dd
        ///  </summary>
        public DateTime? EndDate
        {
            get { return this.GetDateTime(297, 10, "yyyy-MM-dd"); }
            set { this.SetDateTime(value, 297, 10, "yyyy-MM-dd"); }
        }

        #endregion

    }

  
    public partial class ClearWrittenAddressType: PersonRecordWrapper
    {
        #region Common

        public override int Length
        {
            get { return 249; }
        }
        #endregion

        #region Properties

        ///  <summary>
        /// Danish: RECORDTYPE
        /// Equals last three digits of the record name
        ///  </summary>
        public decimal RecordType
        {
            get { return this.GetDecimal(1, 3); }
            set { this.SetDecimal(value, 1, 3); }
        }
        ///  <summary>
        /// Danish: PNR
        /// CPR Number
        ///  </summary>
        public string PNR
        {
            get { return this.GetString(4, 10); }
            set { this.SetString(value, 4, 10); }
        }
        ///  <summary>
        /// Danish: ADRNVN
        /// Addressing name
        ///  </summary>
        public string AddressingName
        {
            get { return this.GetString(14, 34); }
            set { this.SetString(value, 14, 34); }
        }
        ///  <summary>
        /// Danish: CONVN
        /// C/O name
        ///  </summary>
        public string CareOfName
        {
            get { return this.GetString(48, 34); }
            set { this.SetString(value, 48, 34); }
        }
        ///  <summary>
        /// Danish: LOKALITET
        /// Location
        ///  </summary>
        public string Location
        {
            get { return this.GetString(82, 34); }
            set { this.SetString(value, 82, 34); }
        }
        ///  <summary>
        /// Danish: STANDARDADR
        /// Road addressing name, house number, floor, side doors BNR. Labelled Address
        ///  </summary>
        public string LabelledAddress
        {
            get { return this.GetString(116, 34); }
            set { this.SetString(value, 116, 34); }
        }
        ///  <summary>
        /// Danish: BYNVN
        /// City name
        ///  </summary>
        public string CityName
        {
            get { return this.GetString(150, 34); }
            set { this.SetString(value, 150, 34); }
        }
        ///  <summary>
        /// Danish: POSTNR
        /// Post code
        ///  </summary>
        public decimal PostCode
        {
            get { return this.GetDecimal(184, 4); }
            set { this.SetDecimal(value, 184, 4); }
        }
        ///  <summary>
        /// Danish: POSTDISTTXT
        /// Post district text
        ///  </summary>
        public string PostDistrictText
        {
            get { return this.GetString(188, 20); }
            set { this.SetString(value, 188, 20); }
        }
        ///  <summary>
        /// Danish: KOMKOD
        /// Municipality code
        ///  </summary>
        public decimal MunicipalityCode
        {
            get { return this.GetDecimal(208, 4); }
            set { this.SetDecimal(value, 208, 4); }
        }
        ///  <summary>
        /// Danish: VEJKOD
        /// Street code
        ///  </summary>
        public decimal StreetCode
        {
            get { return this.GetDecimal(212, 4); }
            set { this.SetDecimal(value, 212, 4); }
        }
        ///  <summary>
        /// Danish: HUSNR
        /// House number
        ///  </summary>
        public string HouseNumber
        {
            get { return this.GetString(216, 4); }
            set { this.SetString(value, 216, 4); }
        }
        ///  <summary>
        /// Danish: ETAGE
        /// Floor
        ///  </summary>
        public string Floor
        {
            get { return this.GetString(220, 2); }
            set { this.SetString(value, 220, 2); }
        }
        ///  <summary>
        /// Danish: SIDEDOER
        /// Door
        ///  </summary>
        public string Door
        {
            get { return this.GetString(222, 4); }
            set { this.SetString(value, 222, 4); }
        }
        ///  <summary>
        /// Danish: BNR
        /// Building number
        ///  </summary>
        public string BuildingNumber
        {
            get { return this.GetString(226, 4); }
            set { this.SetString(value, 226, 4); }
        }
        ///  <summary>
        /// Danish: VEJADRNVN
        /// Street addressing name
        ///  </summary>
        public string StreetAddressingName
        {
            get { return this.GetString(230, 20); }
            set { this.SetString(value, 230, 20); }
        }

        #endregion

    }

  
    public partial class ProtectionType: PersonRecordWrapper
    {
        #region Common

        public override int Length
        {
            get { return 37; }
        }
        #endregion

        #region Properties

        ///  <summary>
        /// Danish: RECORDTYPE
        /// Equals last three digits of the record name
        ///  </summary>
        public decimal RecordType
        {
            get { return this.GetDecimal(1, 3); }
            set { this.SetDecimal(value, 1, 3); }
        }
        ///  <summary>
        /// Danish: PNR
        /// CPR Number
        ///  </summary>
        public string PNR
        {
            get { return this.GetString(4, 10); }
            set { this.SetString(value, 4, 10); }
        }
        ///  <summary>
        /// Danish: BESKYTTYPE
        /// Protection type
        ///  </summary>
        public decimal ProtectionType_
        {
            get { return this.GetDecimal(14, 4); }
            set { this.SetDecimal(value, 14, 4); }
        }
        ///  <summary>
        /// Danish: START_DT-BESKYTTELSE
        /// Start date yyyy-MM-dd
        ///  </summary>
        public DateTime? StartDate
        {
            get { return this.GetDateTime(18, 10, "yyyy-MM-dd"); }
            set { this.SetDateTime(value, 18, 10, "yyyy-MM-dd"); }
        }
        ///  <summary>
        /// Danish: SLET_DT-BESKYTTELSE
        /// End date yyyy-MM-dd
        ///  </summary>
        public DateTime? EndDate
        {
            get { return this.GetDateTime(28, 10, "yyyy-MM-dd"); }
            set { this.SetDateTime(value, 28, 10, "yyyy-MM-dd"); }
        }

        #endregion

    }

  
    public partial class CurrentDepartureDataType: PersonRecordWrapper
    {
        #region Common

        public override int Length
        {
            get { return 200; }
        }
        #endregion

        #region Properties

        ///  <summary>
        /// Danish: RECORDTYPE
        /// Equals last three digits of the record name
        ///  </summary>
        public decimal RecordType
        {
            get { return this.GetDecimal(1, 3); }
            set { this.SetDecimal(value, 1, 3); }
        }
        ///  <summary>
        /// Danish: PNR
        /// CPR Number
        ///  </summary>
        public string PNR
        {
            get { return this.GetString(4, 10); }
            set { this.SetString(value, 4, 10); }
        }
        ///  <summary>
        /// Danish: UDR_LANDEKOD
        /// Exit country code
        ///  </summary>
        public decimal ExitCountryCode
        {
            get { return this.GetDecimal(14, 4); }
            set { this.SetDecimal(value, 14, 4); }
        }
        ///  <summary>
        /// Danish: UDRDTO
        /// Exit date yyyyMMddTTMM
        ///  </summary>
        public DateTime? ExitDate
        {
            get { return this.GetDateTime(18, 12, "yyyyMMddHHmm"); }
            set { this.SetDateTime(value, 18, 12, "yyyyMMddHHmm"); }
        }
        ///  <summary>
        /// Danish: UDRDTO_UMRK
        /// Exit date uncertainty marker
        ///  </summary>
        public char ExitDateUncertainty
        {
            get { return this.GetChar(30); }
            set { this.SetChar(value, 30); }
        }
        ///  <summary>
        /// Danish: UDLANDADR1
        /// Foreign Address 1
        ///  </summary>
        public string ForeignAddress1
        {
            get { return this.GetString(31, 34); }
            set { this.SetString(value, 31, 34); }
        }
        ///  <summary>
        /// Danish: UDLANDADR2
        /// Foreign Address 2
        ///  </summary>
        public string ForeignAddress2
        {
            get { return this.GetString(65, 34); }
            set { this.SetString(value, 65, 34); }
        }
        ///  <summary>
        /// Danish: UDLANDADR3
        /// Foreign Address 3
        ///  </summary>
        public string ForeignAddress3
        {
            get { return this.GetString(99, 34); }
            set { this.SetString(value, 99, 34); }
        }
        ///  <summary>
        /// Danish: UDLANDADR4
        /// Foreign Address 4
        ///  </summary>
        public string ForeignAddress4
        {
            get { return this.GetString(133, 34); }
            set { this.SetString(value, 133, 34); }
        }
        ///  <summary>
        /// Danish: UDLANDADR5
        /// Foreign Address 5
        ///  </summary>
        public string ForeignAddress5
        {
            get { return this.GetString(167, 34); }
            set { this.SetString(value, 167, 34); }
        }

        #endregion

    }

  
    public partial class ContactAddressType: PersonRecordWrapper
    {
        #region Common

        public override int Length
        {
            get { return 203; }
        }
        #endregion

        #region Properties

        ///  <summary>
        /// Danish: RECORDTYPE
        /// Equals last three digits of the record name
        ///  </summary>
        public decimal RecordType
        {
            get { return this.GetDecimal(1, 3); }
            set { this.SetDecimal(value, 1, 3); }
        }
        ///  <summary>
        /// Danish: PNR
        /// CPR Number
        ///  </summary>
        public string PNR
        {
            get { return this.GetString(4, 10); }
            set { this.SetString(value, 4, 10); }
        }
        ///  <summary>
        /// Danish: ADR1-KONTAKTADR
        /// Contact address line 1
        ///  </summary>
        public string Line1
        {
            get { return this.GetString(14, 34); }
            set { this.SetString(value, 14, 34); }
        }
        ///  <summary>
        /// Danish: ADR2-KONTAKTADR
        /// Contact address line 2
        ///  </summary>
        public string Line2
        {
            get { return this.GetString(48, 34); }
            set { this.SetString(value, 48, 34); }
        }
        ///  <summary>
        /// Danish: ADR3-KONTAKTADR
        /// Contact address line 3
        ///  </summary>
        public string Line3
        {
            get { return this.GetString(82, 34); }
            set { this.SetString(value, 82, 34); }
        }
        ///  <summary>
        /// Danish: ADR4-KONTAKTADR
        /// Contact address line 4
        ///  </summary>
        public string Line4
        {
            get { return this.GetString(116, 34); }
            set { this.SetString(value, 116, 34); }
        }
        ///  <summary>
        /// Danish: ADR5-KONTAKTADR
        /// Contact address line 5
        ///  </summary>
        public string Line5
        {
            get { return this.GetString(150, 34); }
            set { this.SetString(value, 150, 34); }
        }
        ///  <summary>
        /// Danish: START_DT-ADRTXT
        /// Start date yyyy-MM-dd
        ///  </summary>
        public DateTime? StartDate
        {
            get { return this.GetDateTime(184, 10, "yyyy-MM-dd"); }
            set { this.SetDateTime(value, 184, 10, "yyyy-MM-dd"); }
        }
        ///  <summary>
        /// Danish: SLET_DT-ADRTXT
        /// End date yyyy-MM-dd
        ///  </summary>
        public DateTime? EndDate
        {
            get { return this.GetDateTime(194, 10, "yyyy-MM-dd"); }
            set { this.SetDateTime(value, 194, 10, "yyyy-MM-dd"); }
        }

        #endregion

    }

  
    public partial class CurrentDisappearanceInformationType: PersonRecordWrapper
    {
        #region Common

        public override int Length
        {
            get { return 26; }
        }
        #endregion

        #region Properties

        ///  <summary>
        /// Danish: RECORDTYPE
        /// Equals last three digits of the record name
        ///  </summary>
        public decimal RecordType
        {
            get { return this.GetDecimal(1, 3); }
            set { this.SetDecimal(value, 1, 3); }
        }
        ///  <summary>
        /// Danish: PNR
        /// CPR Number
        ///  </summary>
        public string PNR
        {
            get { return this.GetString(4, 10); }
            set { this.SetString(value, 4, 10); }
        }
        ///  <summary>
        /// Danish: FORSVINddTO
        /// Disappearance date yyyyMMddTTMM
        ///  </summary>
        public DateTime? DisappearanceDate
        {
            get { return this.GetDateTime(14, 12, "yyyyMMddHHmm"); }
            set { this.SetDateTime(value, 14, 12, "yyyyMMddHHmm"); }
        }
        ///  <summary>
        /// Danish: FORSVINDDTO_UMRK
        /// Disappearance date uncertainty marker
        ///  </summary>
        public char DisappearanceDateUncertainty
        {
            get { return this.GetChar(26); }
            set { this.SetChar(value, 26); }
        }

        #endregion

    }

  
    public partial class CurrentNameInformationType: PersonRecordWrapper
    {
        #region Common

        public override int Length
        {
            get { return 193; }
        }
        #endregion

        #region Properties

        ///  <summary>
        /// Danish: RECORDTYPE
        /// Equals last three digits of the record name
        ///  </summary>
        public decimal RecordType
        {
            get { return this.GetDecimal(1, 3); }
            set { this.SetDecimal(value, 1, 3); }
        }
        ///  <summary>
        /// Danish: PNR
        /// CPR Number
        ///  </summary>
        public string PNR
        {
            get { return this.GetString(4, 10); }
            set { this.SetString(value, 4, 10); }
        }
        ///  <summary>
        /// Danish: FORNVN
        /// First name (s)
        ///  </summary>
        public string FirstName_s
        {
            get { return this.GetString(14, 50); }
            set { this.SetString(value, 14, 50); }
        }
        ///  <summary>
        /// Danish: FORNVN_MRK
        /// First name marker
        ///  </summary>
        public char FirstNameMarker
        {
            get { return this.GetChar(64); }
            set { this.SetChar(value, 64); }
        }
        ///  <summary>
        /// Danish: MELNVN
        /// Middle name
        ///  </summary>
        public string MiddleName
        {
            get { return this.GetString(65, 40); }
            set { this.SetString(value, 65, 40); }
        }
        ///  <summary>
        /// Danish: MELNVN_MRK
        /// Middle name marker
        ///  </summary>
        public char MiddleNameMarker
        {
            get { return this.GetChar(105); }
            set { this.SetChar(value, 105); }
        }
        ///  <summary>
        /// Danish: EFTERNVN
        /// Last name
        ///  </summary>
        public string LastName
        {
            get { return this.GetString(106, 40); }
            set { this.SetString(value, 106, 40); }
        }
        ///  <summary>
        /// Danish: EFTERNVN_MRK
        /// Last name marker
        ///  </summary>
        public char LastNameMarker
        {
            get { return this.GetChar(146); }
            set { this.SetChar(value, 146); }
        }
        ///  <summary>
        /// Danish: NVNHAENSTART
        /// Name start date yyyyMMddTTMM
        ///  </summary>
        public DateTime? NameStartDate
        {
            get { return this.GetDateTime(147, 12, "yyyyMMddHHmm"); }
            set { this.SetDateTime(value, 147, 12, "yyyyMMddHHmm"); }
        }
        ///  <summary>
        /// Danish: HAENSTART_UMRK-NAVNE
        /// Name start date uncertainty marker
        ///  </summary>
        public char NameStartDateUncertainty
        {
            get { return this.GetChar(159); }
            set { this.SetChar(value, 159); }
        }
        ///  <summary>
        /// Danish: ADRNVN
        /// AddressingName
        ///  </summary>
        public string AddressingName
        {
            get { return this.GetString(160, 34); }
            set { this.SetString(value, 160, 34); }
        }

        #endregion

    }

  
    public partial class BirthRegistrationInformationType: PersonRecordWrapper
    {
        #region Common

        public override int Length
        {
            get { return 37; }
        }
        #endregion

        #region Properties

        ///  <summary>
        /// Danish: RECORDTYPE
        /// Equals last three digits of the record name
        ///  </summary>
        public decimal RecordType
        {
            get { return this.GetDecimal(1, 3); }
            set { this.SetDecimal(value, 1, 3); }
        }
        ///  <summary>
        /// Danish: PNR
        /// CPR Number
        ///  </summary>
        public string PNR
        {
            get { return this.GetString(4, 10); }
            set { this.SetString(value, 4, 10); }
        }
        ///  <summary>
        /// Danish: START_MYNKOD-FØDESTED
        /// Birth registration authority code
        ///  </summary>
        public string BirthRegistrationAuthorityCode
        {
            get { return this.GetString(14, 4); }
            set { this.SetString(value, 14, 4); }
        }
        ///  <summary>
        /// Danish: MYNTXT-FØDESTED
        /// Additional birth registration text
        ///  </summary>
        public string AdditionalBirthRegistrationText
        {
            get { return this.GetString(18, 20); }
            set { this.SetString(value, 18, 20); }
        }

        #endregion

    }

  
    public partial class CurrentCitizenshipType: PersonRecordWrapper
    {
        #region Common

        public override int Length
        {
            get { return 30; }
        }
        #endregion

        #region Properties

        ///  <summary>
        /// Danish: RECORDTYPE
        /// Equals last three digits of the record name
        ///  </summary>
        public decimal RecordType
        {
            get { return this.GetDecimal(1, 3); }
            set { this.SetDecimal(value, 1, 3); }
        }
        ///  <summary>
        /// Danish: PNR
        /// CPR Number
        ///  </summary>
        public string PNR
        {
            get { return this.GetString(4, 10); }
            set { this.SetString(value, 4, 10); }
        }
        ///  <summary>
        /// Danish: LANDEKOD
        /// Country code
        ///  </summary>
        public decimal CountryCode
        {
            get { return this.GetDecimal(14, 4); }
            set { this.SetDecimal(value, 14, 4); }
        }
        ///  <summary>
        /// Danish: HAENSTART-STATSBORGERSKAB
        /// Citizenship start date yyyyMMddTTMM
        ///  </summary>
        public DateTime? CitizenshipStartDate
        {
            get { return this.GetDateTime(18, 12, "yyyyMMddHHmm"); }
            set { this.SetDateTime(value, 18, 12, "yyyyMMddHHmm"); }
        }
        ///  <summary>
        /// Danish: HAENSTART_UMRK-STATSBORGERSKAB
        /// Citizenship start date uncertainty marker
        ///  </summary>
        public char CitizenshipStartDateUncertainty
        {
            get { return this.GetChar(30); }
            set { this.SetChar(value, 30); }
        }

        #endregion

    }

  
    public partial class ChurchInformationType: PersonRecordWrapper
    {
        #region Common

        public override int Length
        {
            get { return 25; }
        }
        #endregion

        #region Properties

        ///  <summary>
        /// Danish: RECORDTYPE
        /// Equals last three digits of the record name
        ///  </summary>
        public decimal RecordType
        {
            get { return this.GetDecimal(1, 3); }
            set { this.SetDecimal(value, 1, 3); }
        }
        ///  <summary>
        /// Danish: PNR
        /// CPR Number
        ///  </summary>
        public string PNR
        {
            get { return this.GetString(4, 10); }
            set { this.SetString(value, 4, 10); }
        }
        ///  <summary>
        /// Danish: FKIRK
        /// church Relationship
        ///  </summary>
        public char ChurchRelationship
        {
            get { return this.GetChar(14); }
            set { this.SetChar(value, 14); }
        }
        ///  <summary>
        /// Danish: START_DT-FOLKEKIRKE
        /// Start date yyyy-MM-dd
        ///  </summary>
        public DateTime? StartDate
        {
            get { return this.GetDateTime(15, 10, "yyyy-MM-dd"); }
            set { this.SetDateTime(value, 15, 10, "yyyy-MM-dd"); }
        }
        ///  <summary>
        /// Danish: START_DT_UMRK-FOLKEKIRKE
        /// Start date uncertainty marker
        ///  </summary>
        public char StartDateUncertainty
        {
            get { return this.GetChar(25); }
            set { this.SetChar(value, 25); }
        }

        #endregion

    }

  
    public partial class CurrentCivilStatusType: PersonRecordWrapper
    {
        #region Common

        public override int Length
        {
            get { return 95; }
        }
        #endregion

        #region Properties

        ///  <summary>
        /// Danish: RECORDTYPE
        /// Equals last three digits of the record name
        ///  </summary>
        public decimal RecordType
        {
            get { return this.GetDecimal(1, 3); }
            set { this.SetDecimal(value, 1, 3); }
        }
        ///  <summary>
        /// Danish: PNR
        /// CPR Number
        ///  </summary>
        public string PNR
        {
            get { return this.GetString(4, 10); }
            set { this.SetString(value, 4, 10); }
        }
        ///  <summary>
        /// Danish: CIVST
        /// Civil status
        ///  </summary>
        public char CivilStatusCode
        {
            get { return this.GetChar(14); }
            set { this.SetChar(value, 14); }
        }
        ///  <summary>
        /// Danish: AEGTEPNR
        /// Spouse PNR
        ///  </summary>
        public string SpousePNR
        {
            get { return this.GetString(15, 10); }
            set { this.SetString(value, 15, 10); }
        }
        ///  <summary>
        /// Danish: AEGTEFOED_DT
        /// Spouse birth date yyyy-MM-dd
        ///  </summary>
        public DateTime? SpouseBirthDate
        {
            get { return this.GetDateTime(25, 10, "yyyy-MM-dd"); }
            set { this.SetDateTime(value, 25, 10, "yyyy-MM-dd"); }
        }
        ///  <summary>
        /// Danish: AEGTEFOEddT_UMRK
        /// Spouse birth date uncertainty
        ///  </summary>
        public char SpouseBirthDateUncertainty
        {
            get { return this.GetChar(35); }
            set { this.SetChar(value, 35); }
        }
        ///  <summary>
        /// Danish: AEGTENVN
        /// Spouse name
        ///  </summary>
        public string SpouseName
        {
            get { return this.GetString(36, 34); }
            set { this.SetString(value, 36, 34); }
        }
        ///  <summary>
        /// Danish: AEGTENVN_MRK
        /// Spouse name marker
        ///  </summary>
        public char SpouseNameMarker
        {
            get { return this.GetChar(70); }
            set { this.SetChar(value, 70); }
        }
        ///  <summary>
        /// Danish: HAENSTART-CIVILSTAND
        /// Civil status start date
        ///  </summary>
        public DateTime? CivilStatusStartDate
        {
            get { return this.GetDateTime(71, 12, "yyyyMMddHHmm"); }
            set { this.SetDateTime(value, 71, 12, "yyyyMMddHHmm"); }
        }
        ///  <summary>
        /// Danish: HAENSTART_UMRK-CIVILSTAND
        /// Civil status start date uncertainty marker
        ///  </summary>
        public char CivilStatusStartDateUncertainty
        {
            get { return this.GetChar(83); }
            set { this.SetChar(value, 83); }
        }
        ///  <summary>
        /// Danish: SEP_HENVIS-CIVILSTAND
        /// Reference to any. separation yyyyMMddTTMM
        ///  </summary>
        public DateTime? ReferenceToAnySeparation
        {
            get { return this.GetDateTime(84, 12, "yyyyMMddHHmm"); }
            set { this.SetDateTime(value, 84, 12, "yyyyMMddHHmm"); }
        }

        #endregion

    }

  
    public partial class CurrentSeparationType: PersonRecordWrapper
    {
        #region Common

        public override int Length
        {
            get { return 36; }
        }
        #endregion

        #region Properties

        ///  <summary>
        /// Danish: RECORDTYPE
        /// Equals last three digits of the record name
        ///  </summary>
        public decimal RecordType
        {
            get { return this.GetDecimal(1, 3); }
            set { this.SetDecimal(value, 1, 3); }
        }
        ///  <summary>
        /// Danish: PNR
        /// CPR Number
        ///  </summary>
        public string PNR
        {
            get { return this.GetString(4, 10); }
            set { this.SetString(value, 4, 10); }
        }
        ///  <summary>
        /// Danish: SEP_HENVIS-SEPARATION
        /// Reference to any. marital status yyyyMMddTTMM
        ///  </summary>
        public DateTime? ReferenceToAnyMaritalStatus
        {
            get { return this.GetDateTime(14, 12, "yyyyMMddHHmm"); }
            set { this.SetDateTime(value, 14, 12, "yyyyMMddHHmm"); }
        }
        ///  <summary>
        /// Danish: START_DT-SEPARATION
        /// Separation start date yyyy-MM-dd
        ///  </summary>
        public DateTime? SeparationStartDate
        {
            get { return this.GetDateTime(26, 10, "yyyy-MM-dd"); }
            set { this.SetDateTime(value, 26, 10, "yyyy-MM-dd"); }
        }
        ///  <summary>
        /// Danish: START_DT_UMRK-SEPARATION
        /// Separation start date uncertainty marker
        ///  </summary>
        public char SeparationStartDateUncertainty
        {
            get { return this.GetChar(36); }
            set { this.SetChar(value, 36); }
        }

        #endregion

    }

  
    public partial class ChildType: PersonRecordWrapper
    {
        #region Common

        public override int Length
        {
            get { return 23; }
        }
        #endregion

        #region Properties

        ///  <summary>
        /// Danish: RECORDTYPE
        /// Equals last three digits of the record name
        ///  </summary>
        public decimal RecordType
        {
            get { return this.GetDecimal(1, 3); }
            set { this.SetDecimal(value, 1, 3); }
        }
        ///  <summary>
        /// Danish: PNR
        /// CPR Number
        ///  </summary>
        public string PNR
        {
            get { return this.GetString(4, 10); }
            set { this.SetString(value, 4, 10); }
        }
        ///  <summary>
        /// Danish: PNR
        /// Child PNR
        ///  </summary>
        public string ChildPNR
        {
            get { return this.GetString(14, 10); }
            set { this.SetString(value, 14, 10); }
        }

        #endregion

    }

  
    public partial class ParentsInformationType: PersonRecordWrapper
    {
        #region Common

        public override int Length
        {
            get { return 147; }
        }
        #endregion

        #region Properties

        ///  <summary>
        /// Danish: RECORDTYPE
        /// Equals last three digits of the record name
        ///  </summary>
        public decimal RecordType
        {
            get { return this.GetDecimal(1, 3); }
            set { this.SetDecimal(value, 1, 3); }
        }
        ///  <summary>
        /// Danish: PNR
        /// CPR Number
        ///  </summary>
        public string PNR
        {
            get { return this.GetString(4, 10); }
            set { this.SetString(value, 4, 10); }
        }
        ///  <summary>
        /// Danish: MOR_DT
        /// Mother date yyyy-MM-dd
        ///  </summary>
        public DateTime? MotherDate
        {
            get { return this.GetDateTime(14, 10, "yyyy-MM-dd"); }
            set { this.SetDateTime(value, 14, 10, "yyyy-MM-dd"); }
        }
        ///  <summary>
        /// Danish: MOR_DT_UMRK
        /// Mother date uncertainty marker
        ///  </summary>
        public char MotherDateUncertainty
        {
            get { return this.GetChar(24); }
            set { this.SetChar(value, 24); }
        }
        ///  <summary>
        /// Danish: PNRMOR
        /// Mother PNR
        ///  </summary>
        public string MotherPNR
        {
            get { return this.GetString(25, 10); }
            set { this.SetString(value, 25, 10); }
        }
        ///  <summary>
        /// Danish: MOR_FOED_DT
        /// Mother birth date yyyy-MM-dd
        ///  </summary>
        public DateTime? MotherBirthDate
        {
            get { return this.GetDateTime(35, 10, "yyyy-MM-dd"); }
            set { this.SetDateTime(value, 35, 10, "yyyy-MM-dd"); }
        }
        ///  <summary>
        /// Danish: MOR_FOED_DT_UMRK
        /// Mother birth date uncertainty marker
        ///  </summary>
        public char MotherBirthDateUncertainty
        {
            get { return this.GetChar(45); }
            set { this.SetChar(value, 45); }
        }
        ///  <summary>
        /// Danish: MORNVN
        /// Mother name
        ///  </summary>
        public string MotherName
        {
            get { return this.GetString(46, 34); }
            set { this.SetString(value, 46, 34); }
        }
        ///  <summary>
        /// Danish: MORNVN_MRK
        /// Mother name marker
        ///  </summary>
        public char MotherNameUncertainty
        {
            get { return this.GetChar(80); }
            set { this.SetChar(value, 80); }
        }
        ///  <summary>
        /// Danish: FAR_DT
        /// Father date yyyy-MM-dd
        ///  </summary>
        public DateTime? FatherDate
        {
            get { return this.GetDateTime(81, 10, "yyyy-MM-dd"); }
            set { this.SetDateTime(value, 81, 10, "yyyy-MM-dd"); }
        }
        ///  <summary>
        /// Danish: FAR_DT_UMRK
        /// Father date uncertainty marker
        ///  </summary>
        public char FatherDateUncertainty
        {
            get { return this.GetChar(91); }
            set { this.SetChar(value, 91); }
        }
        ///  <summary>
        /// Danish: PNRFAR
        /// Father PNR
        ///  </summary>
        public string FatherPNR
        {
            get { return this.GetString(92, 10); }
            set { this.SetString(value, 92, 10); }
        }
        ///  <summary>
        /// Danish: FAR_FOED_DT
        /// Father birth date yyyy-MM-dd
        ///  </summary>
        public DateTime? FatherBirthDate
        {
            get { return this.GetDateTime(102, 10, "yyyy-MM-dd"); }
            set { this.SetDateTime(value, 102, 10, "yyyy-MM-dd"); }
        }
        ///  <summary>
        /// Danish: FAR_FOED_DT_UMRK
        /// Father birth date uncertainty marker
        ///  </summary>
        public char FatherBirthDateUncertainty
        {
            get { return this.GetChar(112); }
            set { this.SetChar(value, 112); }
        }
        ///  <summary>
        /// Danish: FARNVN
        /// Father name
        ///  </summary>
        public string FatherName
        {
            get { return this.GetString(113, 34); }
            set { this.SetString(value, 113, 34); }
        }
        ///  <summary>
        /// Danish: FARNVN_MRK
        /// Father name marker
        ///  </summary>
        public char FatherNameUncertainty
        {
            get { return this.GetChar(147); }
            set { this.SetChar(value, 147); }
        }

        #endregion

    }

  
    public partial class ParentalAuthorityType: PersonRecordWrapper
    {
        #region Common

        public override int Length
        {
            get { return 58; }
        }
        #endregion

        #region Properties

        ///  <summary>
        /// Danish: RECORDTYPE
        /// Equals last three digits of the record name
        ///  </summary>
        public decimal RecordType
        {
            get { return this.GetDecimal(1, 3); }
            set { this.SetDecimal(value, 1, 3); }
        }
        ///  <summary>
        /// Danish: PNR
        /// CPR Number
        ///  </summary>
        public string PNR
        {
            get { return this.GetString(4, 10); }
            set { this.SetString(value, 4, 10); }
        }
        ///  <summary>
        /// Danish: RELTYP-FORÆLDREMYN
        /// Relationship type
        ///  </summary>
        public decimal RelationshipType
        {
            get { return this.GetDecimal(14, 4); }
            set { this.SetDecimal(value, 14, 4); }
        }
        ///  <summary>
        /// Danish: START_DT-FORÆLDREMYN
        /// Custody start date yyyy-MM-dd
        ///  </summary>
        public DateTime? CustodyStartDate
        {
            get { return this.GetDateTime(18, 10, "yyyy-MM-dd"); }
            set { this.SetDateTime(value, 18, 10, "yyyy-MM-dd"); }
        }
        ///  <summary>
        /// Danish: START_DT_UMRK-FORÆLDREMYN
        /// Custody start date uncertainty marker
        ///  </summary>
        public char CustodyStartDateUncertainty
        {
            get { return this.GetChar(28); }
            set { this.SetChar(value, 28); }
        }
        ///  <summary>
        /// Danish: SLET_DT-FORÆLDREMYN
        /// Custody end date yyyy-MM-dd
        ///  </summary>
        public DateTime? CustodyEndDate
        {
            get { return this.GetDateTime(29, 10, "yyyy-MM-dd"); }
            set { this.SetDateTime(value, 29, 10, "yyyy-MM-dd"); }
        }
        ///  <summary>
        /// Danish: RELPNR
        /// Relation PNR
        ///  </summary>
        public string RelationPNR
        {
            get { return this.GetString(39, 10); }
            set { this.SetString(value, 39, 10); }
        }
        ///  <summary>
        /// Danish: START_DT-RELPNR_PNR
        /// Relation PNR start date yyyy-MM-dd
        ///  </summary>
        public DateTime? RelationPNRStartDate
        {
            get { return this.GetDateTime(49, 10, "yyyy-MM-dd"); }
            set { this.SetDateTime(value, 49, 10, "yyyy-MM-dd"); }
        }

        #endregion

    }

  
    public partial class DisempowermentType: PersonRecordWrapper
    {
        #region Common

        public override int Length
        {
            get { return 272; }
        }
        #endregion

        #region Properties

        ///  <summary>
        /// Danish: RECORDTYPE
        /// Equals last three digits of the record name
        ///  </summary>
        public decimal RecordType
        {
            get { return this.GetDecimal(1, 3); }
            set { this.SetDecimal(value, 1, 3); }
        }
        ///  <summary>
        /// Danish: PNR
        /// CPR Number
        ///  </summary>
        public string PNR
        {
            get { return this.GetString(4, 10); }
            set { this.SetString(value, 4, 10); }
        }
        ///  <summary>
        /// Danish: START_DT-UMYNDIG
        /// Disempowerment start date yyyy-MM-dd
        ///  </summary>
        public DateTime? DisempowermentStartDate
        {
            get { return this.GetDateTime(14, 10, "yyyy-MM-dd"); }
            set { this.SetDateTime(value, 14, 10, "yyyy-MM-dd"); }
        }
        ///  <summary>
        /// Danish: PNR
        /// Disempowerment start date uncertainty marker
        ///  </summary>
        public char DisempowermentStartDateUncertainty
        {
            get { return this.GetChar(24); }
            set { this.SetChar(value, 24); }
        }
        ///  <summary>
        /// Danish: SLET_DT-UMYNDIG
        /// Disempowerment end date yyyy-MM-dd
        ///  </summary>
        public DateTime? DisempowermentEndDate
        {
            get { return this.GetDateTime(25, 10, "yyyy-MM-dd"); }
            set { this.SetDateTime(value, 25, 10, "yyyy-MM-dd"); }
        }
        ///  <summary>
        /// Danish: UMYN_RELTYP
        /// Guardian relation type
        ///  </summary>
        public decimal GuardianRelationType
        {
            get { return this.GetDecimal(35, 4); }
            set { this.SetDecimal(value, 35, 4); }
        }
        ///  <summary>
        /// Danish: RELPNR
        /// Relation PNR
        ///  </summary>
        public string RelationPNR
        {
            get { return this.GetString(39, 10); }
            set { this.SetString(value, 39, 10); }
        }
        ///  <summary>
        /// Danish: START_DT-RELPNR_PNR
        /// Relation PNR start date yyyy-MM-dd
        ///  </summary>
        public DateTime? RelationPNRStartDate
        {
            get { return this.GetDateTime(49, 10, "yyyy-MM-dd"); }
            set { this.SetDateTime(value, 49, 10, "yyyy-MM-dd"); }
        }
        ///  <summary>
        /// Danish: RELADRSAT_RELPNR_TXT
        /// Guardian's name
        ///  </summary>
        public string GuardianName
        {
            get { return this.GetString(59, 34); }
            set { this.SetString(value, 59, 34); }
        }
        ///  <summary>
        /// Danish: START_DT-RELPNR_TXT
        /// Guardian's address start date yyyy-MM-dd
        ///  </summary>
        public DateTime? GuardianAddressStartDate
        {
            get { return this.GetDateTime(93, 10, "yyyy-MM-dd"); }
            set { this.SetDateTime(value, 93, 10, "yyyy-MM-dd"); }
        }
        ///  <summary>
        /// Danish: RELTXT1
        /// Relation text 1
        ///  </summary>
        public string RelationText1
        {
            get { return this.GetString(103, 34); }
            set { this.SetString(value, 103, 34); }
        }
        ///  <summary>
        /// Danish: RELTXT2
        /// Relation text 2
        ///  </summary>
        public string RelationText2
        {
            get { return this.GetString(137, 34); }
            set { this.SetString(value, 137, 34); }
        }
        ///  <summary>
        /// Danish: RELTXT3
        /// Relation text 3
        ///  </summary>
        public string RelationText3
        {
            get { return this.GetString(171, 34); }
            set { this.SetString(value, 171, 34); }
        }
        ///  <summary>
        /// Danish: RELTXT4
        /// Relation text 4
        ///  </summary>
        public string RelationText4
        {
            get { return this.GetString(205, 34); }
            set { this.SetString(value, 205, 34); }
        }
        ///  <summary>
        /// Danish: RELTXT5
        /// Relation text 5
        ///  </summary>
        public string RelationText5
        {
            get { return this.GetString(239, 34); }
            set { this.SetString(value, 239, 34); }
        }

        #endregion

    }

  
    public partial class MunicipalConditionsType: PersonRecordWrapper
    {
        #region Common

        public override int Length
        {
            get { return 60; }
        }
        #endregion

        #region Properties

        ///  <summary>
        /// Danish: RECORDTYPE
        /// Equals last three digits of the record name
        ///  </summary>
        public decimal RecordType
        {
            get { return this.GetDecimal(1, 3); }
            set { this.SetDecimal(value, 1, 3); }
        }
        ///  <summary>
        /// Danish: PNR
        /// CPR Number
        ///  </summary>
        public string PNR
        {
            get { return this.GetString(4, 10); }
            set { this.SetString(value, 4, 10); }
        }
        ///  <summary>
        /// Danish: KOMFORHTYP
        /// Municipal condition type
        ///  </summary>
        public decimal MunicipalConditionType
        {
            get { return this.GetDecimal(14, 1); }
            set { this.SetDecimal(value, 14, 1); }
        }
        ///  <summary>
        /// Danish: KOMFORHKOD
        /// Municipal condition code
        ///  </summary>
        public string MunicipalConditionCode
        {
            get { return this.GetString(15, 5); }
            set { this.SetString(value, 15, 5); }
        }
        ///  <summary>
        /// Danish: START_DT-KOMMUNALE-FORHOLD
        /// Municipal condition start date yyyy-MM-dd
        ///  </summary>
        public DateTime? MunicipalConditionStartDate
        {
            get { return this.GetDateTime(20, 10, "yyyy-MM-dd"); }
            set { this.SetDateTime(value, 20, 10, "yyyy-MM-dd"); }
        }
        ///  <summary>
        /// Danish: START_DT_UMRK-KOMMUNALE-FORHOL
        /// Start date uncertainty marker
        ///  </summary>
        public char MunicipalConditionStartDateUncertaintyMarker
        {
            get { return this.GetChar(30); }
            set { this.SetChar(value, 30); }
        }
        ///  <summary>
        /// Danish: BEMAERK-KOMMUNALE-FORHOLD
        /// Municipal condition comment
        ///  </summary>
        public string MunicipalConditionComment
        {
            get { return this.GetString(31, 30); }
            set { this.SetString(value, 31, 30); }
        }

        #endregion

    }

  
    public partial class NotesType: PersonRecordWrapper
    {
        #region Common

        public override int Length
        {
            get { return 75; }
        }
        #endregion

        #region Properties

        ///  <summary>
        /// Danish: RECORDTYPE
        /// Equals last three digits of the record name
        ///  </summary>
        public decimal RecordType
        {
            get { return this.GetDecimal(1, 3); }
            set { this.SetDecimal(value, 1, 3); }
        }
        ///  <summary>
        /// Danish: PNR
        /// CPR Number
        ///  </summary>
        public string PNR
        {
            get { return this.GetString(4, 10); }
            set { this.SetString(value, 4, 10); }
        }
        ///  <summary>
        /// Danish: NOTATNR
        /// Note number
        ///  </summary>
        public decimal NoteNumber
        {
            get { return this.GetDecimal(14, 2); }
            set { this.SetDecimal(value, 14, 2); }
        }
        ///  <summary>
        /// Danish: NOTATLINIE
        /// Note text
        ///  </summary>
        public string NoteText
        {
            get { return this.GetString(16, 40); }
            set { this.SetString(value, 16, 40); }
        }
        ///  <summary>
        /// Danish: START_DT-NOTAT
        /// Note start date YYYY-MM-DD
        ///  </summary>
        public DateTime? StartDate
        {
            get { return this.GetDateTime(56, 10, "yyyy-MM-dd"); }
            set { this.SetDateTime(value, 56, 10, "yyyy-MM-dd"); }
        }
        ///  <summary>
        /// Danish: SLET_DT-NOTAT
        /// Note deletion date YYYY-MM-DD
        ///  </summary>
        public DateTime? EndDate
        {
            get { return this.GetDateTime(66, 10, "yyyy-MM-dd"); }
            set { this.SetDateTime(value, 66, 10, "yyyy-MM-dd"); }
        }

        #endregion

    }

  
    public partial class ElectionInformationType: PersonRecordWrapper
    {
        #region Common

        public override int Length
        {
            get { return 47; }
        }
        #endregion

        #region Properties

        ///  <summary>
        /// Danish: RECORDTYPE
        /// Equals last three digits of the record name
        ///  </summary>
        public decimal RecordType
        {
            get { return this.GetDecimal(1, 3); }
            set { this.SetDecimal(value, 1, 3); }
        }
        ///  <summary>
        /// Danish: PNR
        /// CPR Number
        ///  </summary>
        public decimal PNR
        {
            get { return this.GetDecimal(4, 10); }
            set { this.SetDecimal(value, 4, 10); }
        }
        ///  <summary>
        /// Danish: VALGKODE
        /// Election code
        ///  </summary>
        public decimal ElectionCode
        {
            get { return this.GetDecimal(14, 4); }
            set { this.SetDecimal(value, 14, 4); }
        }
        ///  <summary>
        /// Danish: VALGRET_DT
        /// Voting date YYYY-MM-DD
        ///  </summary>
        public DateTime? VotingDate
        {
            get { return this.GetDateTime(18, 10, "yyyy-MM-dd"); }
            set { this.SetDateTime(value, 18, 10, "yyyy-MM-dd"); }
        }
        ///  <summary>
        /// Danish: START_DT-VALGOPLYSNINGER
        /// Election info start date YYYY-MM-DD
        ///  </summary>
        public DateTime? ElectionInfoStartDate
        {
            get { return this.GetDateTime(28, 10, "yyyy-MM-dd"); }
            set { this.SetDateTime(value, 28, 10, "yyyy-MM-dd"); }
        }
        ///  <summary>
        /// Danish: SLET_DT-VALGOPLYSNINGER
        /// Election info deletion date YYYY-MM-DD
        ///  </summary>
        public DateTime? ElectionInfoDeletionDate
        {
            get { return this.GetDateTime(1, 3, "yyyy-MM-dd"); }
            set { this.SetDateTime(value, 1, 3, "yyyy-MM-dd"); }
        }

        #endregion

    }

  
    public partial class RelocationOrderType: PersonRecordWrapper
    {
        #region Common

        public override int Length
        {
            get { return 63; }
        }
        #endregion

        #region Properties

        ///  <summary>
        /// Danish: RECORDTYPE
        /// Equals last three digits of the record name
        ///  </summary>
        public decimal RecordType
        {
            get { return this.GetDecimal(1, 3); }
            set { this.SetDecimal(value, 1, 3); }
        }

        #endregion

    }

  
    public partial class HistoricalPNRType: PersonRecordWrapper
    {
        #region Common

        public override int Length
        {
            get { return 45; }
        }
        #endregion

        #region Properties

        ///  <summary>
        /// Danish: RECORDTYPE
        /// Equals last three digits of the record name
        ///  </summary>
        public decimal RecordType
        {
            get { return this.GetDecimal(1, 3); }
            set { this.SetDecimal(value, 1, 3); }
        }
        ///  <summary>
        /// Danish: PNRGÆLD
        /// Current CPR Number
        ///  </summary>
        public string PNR
        {
            get { return this.GetString(4, 10); }
            set { this.SetString(value, 4, 10); }
        }
        ///  <summary>
        /// Danish: PNR
        /// Old CPR Number
        ///  </summary>
        public string OldPNR
        {
            get { return this.GetString(14, 10); }
            set { this.SetString(value, 14, 10); }
        }
        ///  <summary>
        /// Danish: START_DT-PERSON
        /// Start date
        ///  </summary>
        public DateTime? OldPNRStartDate
        {
            get { return this.GetDateTime(24, 10, "yyyy-MM-dd"); }
            set { this.SetDateTime(value, 24, 10, "yyyy-MM-dd"); }
        }
        ///  <summary>
        /// Danish: START_DT_UMRK-PERSON
        /// Start date uncertainty
        ///  </summary>
        public char OldPNRStartDateUncertainty
        {
            get { return this.GetChar(34); }
            set { this.SetChar(value, 34); }
        }
        ///  <summary>
        /// Danish: SLUT_DT-PERSON
        /// End date
        ///  </summary>
        public DateTime? OldPNREndDate
        {
            get { return this.GetDateTime(35, 10, "yyyy-MM-dd"); }
            set { this.SetDateTime(value, 35, 10, "yyyy-MM-dd"); }
        }
        ///  <summary>
        /// Danish: SLUT_DT_UMRK-PERSON
        /// Start date uncertainty
        ///  </summary>
        public char OldPNREndDateUncertainty
        {
            get { return this.GetChar(45); }
            set { this.SetChar(value, 45); }
        }

        #endregion

    }

  
    public partial class HistoricalAddressType: PersonRecordWrapper
    {
        #region Common

        public override int Length
        {
            get { return 96; }
        }
        #endregion

        #region Properties

        ///  <summary>
        /// Danish: RECORDTYPE
        /// Equals last three digits of the record name
        ///  </summary>
        public decimal RecordType
        {
            get { return this.GetDecimal(1, 3); }
            set { this.SetDecimal(value, 1, 3); }
        }
        ///  <summary>
        /// Danish: PNR
        /// CPR Number
        ///  </summary>
        public string PNR
        {
            get { return this.GetString(4, 10); }
            set { this.SetString(value, 4, 10); }
        }
        ///  <summary>
        /// Danish: ANNKOR
        /// Correction marker
        ///  </summary>
        public char CorrectionMarker
        {
            get { return this.GetChar(14); }
            set { this.SetChar(value, 14); }
        }
        ///  <summary>
        /// Danish: KOMKOD
        /// Municipality
        ///  </summary>
        public decimal MunicipalityCode
        {
            get { return this.GetDecimal(15, 4); }
            set { this.SetDecimal(value, 15, 4); }
        }
        ///  <summary>
        /// Danish: VEJKOD
        /// Street
        ///  </summary>
        public decimal StreetCode
        {
            get { return this.GetDecimal(19, 4); }
            set { this.SetDecimal(value, 19, 4); }
        }
        ///  <summary>
        /// Danish: HUSNR
        /// House
        ///  </summary>
        public string HouseNumber
        {
            get { return this.GetString(23, 4); }
            set { this.SetString(value, 23, 4); }
        }
        ///  <summary>
        /// Danish: ETAGE
        /// Floor
        ///  </summary>
        public string Floor
        {
            get { return this.GetString(27, 2); }
            set { this.SetString(value, 27, 2); }
        }
        ///  <summary>
        /// Danish: SIDEDOER
        /// Door
        ///  </summary>
        public string Door
        {
            get { return this.GetString(29, 4); }
            set { this.SetString(value, 29, 4); }
        }
        ///  <summary>
        /// Danish: BNR
        /// Building number
        ///  </summary>
        public string BuildingNumber
        {
            get { return this.GetString(33, 4); }
            set { this.SetString(value, 33, 4); }
        }
        ///  <summary>
        /// Danish: CONVN
        /// C/O name
        ///  </summary>
        public string CareOfName
        {
            get { return this.GetString(37, 34); }
            set { this.SetString(value, 37, 34); }
        }
        ///  <summary>
        /// Danish: TILFLYDTO
        /// Relocation date yyyyMMddTTMM
        ///  </summary>
        public DateTime? RelocationDate
        {
            get { return this.GetDateTime(71, 12, "yyyyMMddHHmm"); }
            set { this.SetDateTime(value, 71, 12, "yyyyMMddHHmm"); }
        }
        ///  <summary>
        /// Danish: TILFLYDT_UMRK
        /// Relocation date uncertainty marker
        ///  </summary>
        public char RelocationDateUncertainty
        {
            get { return this.GetChar(83); }
            set { this.SetChar(value, 83); }
        }
        ///  <summary>
        /// Danish: FRAFLYDTO
        /// Leaving date yyyyMMddTTMM
        ///  </summary>
        public DateTime? LeavingDate
        {
            get { return this.GetDateTime(84, 12, "yyyyMMddHHmm"); }
            set { this.SetDateTime(value, 84, 12, "yyyyMMddHHmm"); }
        }
        ///  <summary>
        /// Danish: FRAFLYDTO_UMRK
        /// Leaving date uncertainty marker
        ///  </summary>
        public char LeavingDateUncertainty
        {
            get { return this.GetChar(96); }
            set { this.SetChar(value, 96); }
        }

        #endregion

    }

  
    public partial class HistoricalDepartureType: PersonRecordWrapper
    {
        #region Common

        public override int Length
        {
            get { return 218; }
        }
        #endregion

        #region Properties

        ///  <summary>
        /// Danish: RECORDTYPE
        /// Equals last three digits of the record name
        ///  </summary>
        public decimal RecordType
        {
            get { return this.GetDecimal(1, 3); }
            set { this.SetDecimal(value, 1, 3); }
        }
        ///  <summary>
        /// Danish: PNR
        /// CPR Number
        ///  </summary>
        public string PNR
        {
            get { return this.GetString(4, 10); }
            set { this.SetString(value, 4, 10); }
        }
        ///  <summary>
        /// Danish: ANNKOR
        /// Correction marker
        ///  </summary>
        public char CorrectionMarker
        {
            get { return this.GetChar(14); }
            set { this.SetChar(value, 14); }
        }
        ///  <summary>
        /// Danish: UDR_LANDEKOD
        /// Exit country code
        ///  </summary>
        public decimal ExitCountryCode
        {
            get { return this.GetDecimal(15, 4); }
            set { this.SetDecimal(value, 15, 4); }
        }
        ///  <summary>
        /// Danish: UDRDTO
        /// Exit date yyyyMMddTTMM
        ///  </summary>
        public DateTime? ExitDate
        {
            get { return this.GetDateTime(19, 12, "yyyyMMddHHmm"); }
            set { this.SetDateTime(value, 19, 12, "yyyyMMddHHmm"); }
        }
        ///  <summary>
        /// Danish: UDRDTO_UMRK
        /// Exit date uncertainty marker
        ///  </summary>
        public char ExitDateUncertainty
        {
            get { return this.GetChar(31); }
            set { this.SetChar(value, 31); }
        }
        ///  <summary>
        /// Danish: INDR_LANDEKOD
        /// Entry country code
        ///  </summary>
        public decimal EntryCountryCode
        {
            get { return this.GetDecimal(32, 4); }
            set { this.SetDecimal(value, 32, 4); }
        }
        ///  <summary>
        /// Danish: INDRDTO
        /// Entry date yyyyMMddTTMM
        ///  </summary>
        public DateTime? EntryDate
        {
            get { return this.GetDateTime(36, 12, "yyyyMMddHHmm"); }
            set { this.SetDateTime(value, 36, 12, "yyyyMMddHHmm"); }
        }
        ///  <summary>
        /// Danish: INDRDTO_UMRK
        /// Entry date uncertainty marker
        ///  </summary>
        public char EntryDateUncertainty
        {
            get { return this.GetChar(48); }
            set { this.SetChar(value, 48); }
        }
        ///  <summary>
        /// Danish: UDLANDADR1
        /// Foreign Address 1
        ///  </summary>
        public string ForeignAddress1
        {
            get { return this.GetString(49, 34); }
            set { this.SetString(value, 49, 34); }
        }
        ///  <summary>
        /// Danish: UDLANDADR2
        /// Foreign Address 2
        ///  </summary>
        public string ForeignAddress2
        {
            get { return this.GetString(83, 34); }
            set { this.SetString(value, 83, 34); }
        }
        ///  <summary>
        /// Danish: UDLANDADR3
        /// Foreign Address 3
        ///  </summary>
        public string ForeignAddress3
        {
            get { return this.GetString(117, 34); }
            set { this.SetString(value, 117, 34); }
        }
        ///  <summary>
        /// Danish: UDLANDADR4
        /// Foreign Address 4
        ///  </summary>
        public string ForeignAddress4
        {
            get { return this.GetString(151, 34); }
            set { this.SetString(value, 151, 34); }
        }
        ///  <summary>
        /// Danish: UDLANDADR5
        /// Foreign Address 5
        ///  </summary>
        public string ForeignAddress5
        {
            get { return this.GetString(185, 34); }
            set { this.SetString(value, 185, 34); }
        }

        #endregion

    }

  
    public partial class HistoricalDisappearanceType: PersonRecordWrapper
    {
        #region Common

        public override int Length
        {
            get { return 40; }
        }
        #endregion

        #region Properties

        ///  <summary>
        /// Danish: RECORDTYPE
        /// Equals last three digits of the record name
        ///  </summary>
        public decimal RecordType
        {
            get { return this.GetDecimal(1, 3); }
            set { this.SetDecimal(value, 1, 3); }
        }
        ///  <summary>
        /// Danish: PNR
        /// CPR Number
        ///  </summary>
        public string PNR
        {
            get { return this.GetString(4, 10); }
            set { this.SetString(value, 4, 10); }
        }
        ///  <summary>
        /// Danish: ANNKOR
        /// Correction marker
        ///  </summary>
        public char CorrectionMarker
        {
            get { return this.GetChar(14); }
            set { this.SetChar(value, 14); }
        }
        ///  <summary>
        /// Danish: FORSVINDDTO
        /// Disappearance date yyyyMMddTTMM
        ///  </summary>
        public DateTime? DisappearanceDate
        {
            get { return this.GetDateTime(15, 12, "yyyyMMddHHmm"); }
            set { this.SetDateTime(value, 15, 12, "yyyyMMddHHmm"); }
        }
        ///  <summary>
        /// Danish: FORSVINDDTO_UMRK
        /// Disappearance date uncertainty marker
        ///  </summary>
        public char DisappearanceDateUncertainty
        {
            get { return this.GetChar(27); }
            set { this.SetChar(value, 27); }
        }
        ///  <summary>
        /// Danish: GENFINDDTO
        /// Retrieval date yyyyMMddTTMM
        ///  </summary>
        public DateTime? RetrievalDate
        {
            get { return this.GetDateTime(28, 12, "yyyyMMddHHmm"); }
            set { this.SetDateTime(value, 28, 12, "yyyyMMddHHmm"); }
        }
        ///  <summary>
        /// Danish: GENFINDDTO_UMRK
        /// Retrieval date uncertainty marker
        ///  </summary>
        public char RetrievalDateUncertainty
        {
            get { return this.GetChar(40); }
            set { this.SetChar(value, 40); }
        }

        #endregion

    }

  
    public partial class HistoricalNameType: PersonRecordWrapper
    {
        #region Common

        public override int Length
        {
            get { return 173; }
        }
        #endregion

        #region Properties

        ///  <summary>
        /// Danish: RECORDTYPE
        /// Equals last three digits of the record name
        ///  </summary>
        public decimal RecordType
        {
            get { return this.GetDecimal(1, 3); }
            set { this.SetDecimal(value, 1, 3); }
        }
        ///  <summary>
        /// Danish: PNR
        /// CPR Number
        ///  </summary>
        public string PNR
        {
            get { return this.GetString(4, 10); }
            set { this.SetString(value, 4, 10); }
        }
        ///  <summary>
        /// Danish: ANNKOR
        /// Correction marker
        ///  </summary>
        public char CorrectionMarker
        {
            get { return this.GetChar(14); }
            set { this.SetChar(value, 14); }
        }
        ///  <summary>
        /// Danish: FORNVN
        /// First name(s)
        ///  </summary>
        public string FirstName_s
        {
            get { return this.GetString(15, 50); }
            set { this.SetString(value, 15, 50); }
        }
        ///  <summary>
        /// Danish: FORNVN_MRK
        /// First name marker
        ///  </summary>
        public char FirstNameMarker
        {
            get { return this.GetChar(65); }
            set { this.SetChar(value, 65); }
        }
        ///  <summary>
        /// Danish: MELNVN
        /// Middle name
        ///  </summary>
        public string MiddleName
        {
            get { return this.GetString(66, 40); }
            set { this.SetString(value, 66, 40); }
        }
        ///  <summary>
        /// Danish: MELNVN_MRK
        /// Middle name marker
        ///  </summary>
        public char MiddleNameMarker
        {
            get { return this.GetChar(106); }
            set { this.SetChar(value, 106); }
        }
        ///  <summary>
        /// Danish: EFTERNVN
        /// Last name
        ///  </summary>
        public string LastName
        {
            get { return this.GetString(107, 40); }
            set { this.SetString(value, 107, 40); }
        }
        ///  <summary>
        /// Danish: EFTERNVN_MRK
        /// Last name marker
        ///  </summary>
        public char LastNameMarker
        {
            get { return this.GetChar(147); }
            set { this.SetChar(value, 147); }
        }
        ///  <summary>
        /// Danish: NVNHAENSTART
        /// Name start date ÅÅÅÅMMDDTTMM
        ///  </summary>
        public DateTime? NameStartDate
        {
            get { return this.GetDateTime(148, 12, "yyyyMMddHHmm"); }
            set { this.SetDateTime(value, 148, 12, "yyyyMMddHHmm"); }
        }
        ///  <summary>
        /// Danish: HAENSTART_UMRK-NAVNE
        /// Name start date uncertainty marker
        ///  </summary>
        public char NameStartDateUncertainty
        {
            get { return this.GetChar(160); }
            set { this.SetChar(value, 160); }
        }
        ///  <summary>
        /// Danish: NVNHAENSLUT
        /// Name end date ÅÅÅÅMMDDTTMM
        ///  </summary>
        public DateTime? NameEndDate
        {
            get { return this.GetDateTime(161, 12, "yyyyMMddHHmm"); }
            set { this.SetDateTime(value, 161, 12, "yyyyMMddHHmm"); }
        }
        ///  <summary>
        /// Danish: HAENSLUT_UMRK-NAVNE
        /// Name end date uncertainty marker
        ///  </summary>
        public char NameEndDateUncertainty
        {
            get { return this.GetChar(173); }
            set { this.SetChar(value, 173); }
        }

        #endregion

    }

  
    public partial class HistoricalCitizenshipType: PersonRecordWrapper
    {
        #region Common

        public override int Length
        {
            get { return 44; }
        }
        #endregion

        #region Properties

        ///  <summary>
        /// Danish: RECORDTYPE
        /// Equals last three digits of the record name
        ///  </summary>
        public decimal RecordType
        {
            get { return this.GetDecimal(1, 3); }
            set { this.SetDecimal(value, 1, 3); }
        }
        ///  <summary>
        /// Danish: PNR
        /// CPR Number
        ///  </summary>
        public string PNR
        {
            get { return this.GetString(4, 10); }
            set { this.SetString(value, 4, 10); }
        }
        ///  <summary>
        /// Danish: ANNKOR
        /// Correction marker
        ///  </summary>
        public char CorrectionMarker
        {
            get { return this.GetChar(14); }
            set { this.SetChar(value, 14); }
        }
        ///  <summary>
        /// Danish: LANDEKOD
        /// Country code
        ///  </summary>
        public decimal CountryCode
        {
            get { return this.GetDecimal(15, 4); }
            set { this.SetDecimal(value, 15, 4); }
        }
        ///  <summary>
        /// Danish: HAENSTART-STATSBORGERSKAB
        /// Citizenship start date yyyyMMddTTMM
        ///  </summary>
        public DateTime? CitizenshipStartDate
        {
            get { return this.GetDateTime(19, 12, "yyyyMMddHHmm"); }
            set { this.SetDateTime(value, 19, 12, "yyyyMMddHHmm"); }
        }
        ///  <summary>
        /// Danish: HAENSTART_UMRK-STATSBORGERSKAB
        /// Citizenship start date uncertainty marker
        ///  </summary>
        public char CitizenshipStartDateUncertainty
        {
            get { return this.GetChar(31); }
            set { this.SetChar(value, 31); }
        }
        ///  <summary>
        /// Danish: HAENSLUT-STATSBORGERSKAB
        /// Citizenship end date yyyyMMddTTMM
        ///  </summary>
        public DateTime? CitizenshipEndDate
        {
            get { return this.GetDateTime(32, 12, "yyyyMMddHHmm"); }
            set { this.SetDateTime(value, 32, 12, "yyyyMMddHHmm"); }
        }
        ///  <summary>
        /// Danish: HAENSLUT_UMRK-STATSBORGERSKAB
        /// Citizenship end date uncertainty marker
        ///  </summary>
        public char CitizenshipEndDateUncertainty
        {
            get { return this.GetChar(44); }
            set { this.SetChar(value, 44); }
        }

        #endregion

    }

  
    public partial class HistoricalChurchInformationType: PersonRecordWrapper
    {
        #region Common

        public override int Length
        {
            get { return 36; }
        }
        #endregion

        #region Properties

        ///  <summary>
        /// Danish: RECORDTYPE
        /// Equals last three digits of the record name
        ///  </summary>
        public decimal RecordType
        {
            get { return this.GetDecimal(1, 3); }
            set { this.SetDecimal(value, 1, 3); }
        }
        ///  <summary>
        /// Danish: PNR
        /// CPR Number
        ///  </summary>
        public string PNR
        {
            get { return this.GetString(4, 10); }
            set { this.SetString(value, 4, 10); }
        }
        ///  <summary>
        /// Danish: FKIRK
        /// church Relationship
        ///  </summary>
        public char ChurchRelationship
        {
            get { return this.GetChar(14); }
            set { this.SetChar(value, 14); }
        }
        ///  <summary>
        /// Danish: START_DT-FOLKEKIRKE
        /// Start date yyyy-MM-dd
        ///  </summary>
        public DateTime? StartDate
        {
            get { return this.GetDateTime(15, 10, "yyyy-MM-dd"); }
            set { this.SetDateTime(value, 15, 10, "yyyy-MM-dd"); }
        }
        ///  <summary>
        /// Danish: START_DT_UMRK-FOLKEKIRKE
        /// Start date uncertainty marker
        ///  </summary>
        public char StartDateUncertainty
        {
            get { return this.GetChar(25); }
            set { this.SetChar(value, 25); }
        }
        ///  <summary>
        /// Danish: SLUT_DT-FOLKEKIRKE
        /// End date yyyy-MM-dd
        ///  </summary>
        public DateTime? EndDate
        {
            get { return this.GetDateTime(26, 10, "yyyy-MM-dd"); }
            set { this.SetDateTime(value, 26, 10, "yyyy-MM-dd"); }
        }
        ///  <summary>
        /// Danish: SLUT_DT_UMRK-FOLKEKIRKE
        /// End date uncertainty marker
        ///  </summary>
        public char EndDateUncertainty
        {
            get { return this.GetChar(36); }
            set { this.SetChar(value, 36); }
        }

        #endregion

    }

  
    public partial class HistoricalCivilStatusType: PersonRecordWrapper
    {
        #region Common

        public override int Length
        {
            get { return 109; }
        }
        #endregion

        #region Properties

        ///  <summary>
        /// Danish: RECORDTYPE
        /// Equals last three digits of the record name
        ///  </summary>
        public decimal RecordType
        {
            get { return this.GetDecimal(1, 3); }
            set { this.SetDecimal(value, 1, 3); }
        }
        ///  <summary>
        /// Danish: PNR
        /// CPR Number
        ///  </summary>
        public string PNR
        {
            get { return this.GetString(4, 10); }
            set { this.SetString(value, 4, 10); }
        }
        ///  <summary>
        /// Danish: ANNKOR
        /// Edit / Undo marker
        ///  </summary>
        public char CorrectionMarker
        {
            get { return this.GetChar(14); }
            set { this.SetChar(value, 14); }
        }
        ///  <summary>
        /// Danish: CIVST
        /// Civil status
        ///  </summary>
        public char CivilStatusCode
        {
            get { return this.GetChar(15); }
            set { this.SetChar(value, 15); }
        }
        ///  <summary>
        /// Danish: AEGTEPNR
        /// Spouse PNR
        ///  </summary>
        public string SpousePNR
        {
            get { return this.GetString(16, 10); }
            set { this.SetString(value, 16, 10); }
        }
        ///  <summary>
        /// Danish: AEGTEFOED_DT
        /// Spouse Birth date ÅÅÅÅ-MM-DD
        ///  </summary>
        public DateTime? SpouseBirthdate
        {
            get { return this.GetDateTime(26, 10, "yyyy-MM-dd"); }
            set { this.SetDateTime(value, 26, 10, "yyyy-MM-dd"); }
        }
        ///  <summary>
        /// Danish: AEGTEFOEDDT_UMRK
        /// Spouse birthdate uncertainty
        ///  </summary>
        public char SpouseBirthdateUncertainty
        {
            get { return this.GetChar(36); }
            set { this.SetChar(value, 36); }
        }
        ///  <summary>
        /// Danish: AEGTENVN
        /// Spouse name
        ///  </summary>
        public string SpouseName
        {
            get { return this.GetString(37, 34); }
            set { this.SetString(value, 37, 34); }
        }
        ///  <summary>
        /// Danish: AEGTENVN_MRK
        /// Spouse name marker
        ///  </summary>
        public char SpouseNameMarker
        {
            get { return this.GetChar(71); }
            set { this.SetChar(value, 71); }
        }
        ///  <summary>
        /// Danish: HAENSTART-CIVILSTAND
        /// Civil status start date ÅÅÅÅMMDDTTMM
        ///  </summary>
        public DateTime? CivilStatusStartDate
        {
            get { return this.GetDateTime(72, 12, "yyyyMMddHHmm"); }
            set { this.SetDateTime(value, 72, 12, "yyyyMMddHHmm"); }
        }
        ///  <summary>
        /// Danish: HAENSTART_UMRK-CIVILSTAND
        /// Civil status start date uncertainty
        ///  </summary>
        public char CivilStatusStartDateUncertainty
        {
            get { return this.GetChar(84); }
            set { this.SetChar(value, 84); }
        }
        ///  <summary>
        /// Danish: HAENSLUT-CIVILSTAND
        /// Civil status end date ÅÅÅÅMMDDTTMM
        ///  </summary>
        public DateTime? CivilStatusEndDate
        {
            get { return this.GetDateTime(85, 12, "yyyyMMddHHmm"); }
            set { this.SetDateTime(value, 85, 12, "yyyyMMddHHmm"); }
        }
        ///  <summary>
        /// Danish: HAENSLUT_UMRK-CIVILSTAND
        /// Civil status end date uncertainty
        ///  </summary>
        public char CivilStatusEndDateUncertainty
        {
            get { return this.GetChar(97); }
            set { this.SetChar(value, 97); }
        }
        ///  <summary>
        /// Danish: SEP_HENVIS-CIVILSTAND
        /// Reference to any separation ÅÅÅÅMMDDTTMM
        ///  </summary>
        public DateTime? ReferenceToAnySeparation
        {
            get { return this.GetDateTime(98, 12, "yyyyMMddHHmm"); }
            set { this.SetDateTime(value, 98, 12, "yyyyMMddHHmm"); }
        }

        #endregion

    }

  
    public partial class HistoricalSeparationType: PersonRecordWrapper
    {
        #region Common

        public override int Length
        {
            get { return 48; }
        }
        #endregion

        #region Properties

        ///  <summary>
        /// Danish: RECORDTYPE
        /// Equals last three digits of the record name
        ///  </summary>
        public decimal RecordType
        {
            get { return this.GetDecimal(1, 3); }
            set { this.SetDecimal(value, 1, 3); }
        }
        ///  <summary>
        /// Danish: PNR
        /// CPR Number
        ///  </summary>
        public string PNR
        {
            get { return this.GetString(4, 10); }
            set { this.SetString(value, 4, 10); }
        }
        ///  <summary>
        /// Danish: ANNKOR
        /// Edit / Undo marker
        ///  </summary>
        public char CorrectionMarker
        {
            get { return this.GetChar(14); }
            set { this.SetChar(value, 14); }
        }
        ///  <summary>
        /// Danish: SEP_HENVIS-SEPARATION
        /// Reference to any. marital status yyyyMMddTTMM
        ///  </summary>
        public DateTime? ReferenceToAnyMaritalStatus
        {
            get { return this.GetDateTime(15, 12, "yyyyMMddHHmm"); }
            set { this.SetDateTime(value, 15, 12, "yyyyMMddHHmm"); }
        }
        ///  <summary>
        /// Danish: START_DT-SEPARATION
        /// Separation start date yyyy-MM-dd
        ///  </summary>
        public DateTime? SeparationStartDate
        {
            get { return this.GetDateTime(27, 10, "yyyy-MM-dd"); }
            set { this.SetDateTime(value, 27, 10, "yyyy-MM-dd"); }
        }
        ///  <summary>
        /// Danish: START_DT_UMRK-SEPARATION
        /// Separation start date uncertainty marker
        ///  </summary>
        public char SeparationStartDateUncertainty
        {
            get { return this.GetChar(37); }
            set { this.SetChar(value, 37); }
        }
        ///  <summary>
        /// Danish: SLUT_DT-SEPARATION
        /// Separation end date yyyy-MM-dd
        ///  </summary>
        public DateTime? SeparationEndDate
        {
            get { return this.GetDateTime(38, 10, "yyyy-MM-dd"); }
            set { this.SetDateTime(value, 38, 10, "yyyy-MM-dd"); }
        }
        ///  <summary>
        /// Danish: SLUT_DT_UMRK-SEPARATION
        /// Separation end date uncertainty marker
        ///  </summary>
        public char SeparationEndDateUncertainty
        {
            get { return this.GetChar(48); }
            set { this.SetChar(value, 48); }
        }

        #endregion

    }

  
    public partial class EventsType: PersonRecordWrapper
    {
        #region Common

        public override int Length
        {
            get { return 45; }
        }
        #endregion

        #region Properties

        ///  <summary>
        /// Danish: RECORDTYPE
        /// Equals last three digits of the record name
        ///  </summary>
        public decimal RecordType
        {
            get { return this.GetDecimal(1, 3); }
            set { this.SetDecimal(value, 1, 3); }
        }
        ///  <summary>
        /// Danish: PNR
        /// CPR Number
        ///  </summary>
        public string PNR
        {
            get { return this.GetString(4, 10); }
            set { this.SetString(value, 4, 10); }
        }
        ///  <summary>
        /// Danish: TIMESTAMPU
        /// Update date and time
        ///  </summary>
        public DateTime? CprUpdateDate
        {
            get { return this.GetDateTime(14, 12, "yyyyMMddHHmm"); }
            set { this.SetDateTime(value, 14, 12, "yyyyMMddHHmm"); }
        }
        ///  <summary>
        /// Danish: HAENDELSE
        /// The event
        ///  </summary>
        public string Event_
        {
            get { return this.GetString(26, 3); }
            set { this.SetString(value, 26, 3); }
        }
        ///  <summary>
        /// Danish: AFLEDTMRK
        /// Derived mark
        ///  </summary>
        public string DerivedMark
        {
            get { return this.GetString(29, 2); }
            set { this.SetString(value, 29, 2); }
        }

        #endregion

    }

  
    public partial class ErrorRecordType: PersonRecordWrapper
    {
        #region Common

        public override int Length
        {
            get { return 157; }
        }
        #endregion

        #region Properties

        ///  <summary>
        /// Danish: RECORDTYPE
        /// Equals last three digits of the record name
        ///  </summary>
        public decimal RecordType
        {
            get { return this.GetDecimal(1, 3); }
            set { this.SetDecimal(value, 1, 3); }
        }
        ///  <summary>
        /// Danish: SORTFELT-10
        /// Can such. be PNR, FOEDDTO, KOEN (SEX) KOMKOD, VEJKOD
        ///  </summary>
        public string ErrorField
        {
            get { return this.GetString(4, 10); }
            set { this.SetString(value, 4, 10); }
        }
        ///  <summary>
        /// Danish: INDDATA
        /// Input
        ///  </summary>
        public string Input
        {
            get { return this.GetString(14, 75); }
            set { this.SetString(value, 14, 75); }
        }
        ///  <summary>
        /// Danish: FEJLNR
        /// Error number
        ///  </summary>
        public decimal ErrorNumber
        {
            get { return this.GetDecimal(89, 4); }
            set { this.SetDecimal(value, 89, 4); }
        }
        ///  <summary>
        /// Danish: FEJLTXT-UDTRÆK
        /// Error text
        ///  </summary>
        public string ErrorText
        {
            get { return this.GetString(93, 65); }
            set { this.SetString(value, 93, 65); }
        }

        #endregion

    }

  
    public partial class SubscriptionDeletionReceiptType: PersonRecordWrapper
    {
        #region Common

        public override int Length
        {
            get { return 43; }
        }
        #endregion

        #region Properties

        ///  <summary>
        /// Danish: RECORDTYPE
        /// Equals last three digits of the record name
        ///  </summary>
        public decimal RecordType
        {
            get { return this.GetDecimal(1, 3); }
            set { this.SetDecimal(value, 1, 3); }
        }
        ///  <summary>
        /// Danish: PNR
        /// CPR Number
        ///  </summary>
        public string PNR
        {
            get { return this.GetString(4, 10); }
            set { this.SetString(value, 4, 10); }
        }
        ///  <summary>
        /// Danish: TIMESTAMPU
        /// Update date and time
        ///  </summary>
        public DateTime? UpdateTime
        {
            get { return this.GetDateTime(14, 12, "yyyyMMddHHmm"); }
            set { this.SetDateTime(value, 14, 12, "yyyyMMddHHmm"); }
        }
        ///  <summary>
        /// Danish: HAENDELSE
        /// Incident
        ///  </summary>
        public string Incident
        {
            get { return this.GetString(26, 3); }
            set { this.SetString(value, 26, 3); }
        }
        ///  <summary>
        /// Danish: NGLKONST
        /// Key Constant, blank on output if the field is not filled out input
        ///  </summary>
        public string KeyConstant
        {
            get { return this.GetString(29, 15); }
            set { this.SetString(value, 29, 15); }
        }

        #endregion

    }

  
    public partial class EndRecordType: Wrapper
    {
        #region Common

        public override int Length
        {
            get { return 21; }
        }
        #endregion

        #region Properties

        ///  <summary>
        /// Danish: RECORDTYPE
        /// Equals last three digits of the record name
        ///  </summary>
        public decimal RecordType
        {
            get { return this.GetDecimal(1, 3); }
            set { this.SetDecimal(value, 1, 3); }
        }
        ///  <summary>
        /// Danish: TAELLER
        /// BLACK BOX 10
        ///  </summary>
        public string BlackBox10
        {
            get { return this.GetString(4, 10); }
            set { this.SetString(value, 4, 10); }
        }
        ///  <summary>
        /// Danish: TAELLER
        /// Counter
        ///  </summary>
        public string Counter
        {
            get { return this.GetString(14, 8); }
            set { this.SetString(value, 14, 8); }
        }

        #endregion

    }

  
    }
  