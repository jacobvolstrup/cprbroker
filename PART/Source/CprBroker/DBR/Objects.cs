
    using System;
    using System.Collections.Generic;
    using CprBroker.Schemas.Wrappers;
  
    using CprBroker.Providers.DPR;
  
    namespace CprBroker.DBR
    {
    
    public partial class ClassicRequestType: DiversionRequest
    {
        #region Common

        public override int Length
        {
            get { return 12; }
        }
        #endregion

        #region Properties

        public InquiryType Type
        {
            get { return this.GetEnum<InquiryType>(1, 1); }
            set { this.SetEnum<InquiryType>(value, 1, 1); }
        }
        public DetailType LargeData
        {
            get { return this.GetEnum<DetailType>(2, 1); }
            set { this.SetEnum<DetailType>(value, 2, 1); }
        }
        public string PNR
        {
            get { return this.GetString(3, 10); }
            set { this.SetString(value, 3, 10); }
        }

        #endregion

    }

  
    public partial class ClassicResponseType: DiversionResponse
    {
        #region Common

        public override int Length
        {
            get { return 236; }
        }
        #endregion

        #region Properties

        public InquiryType Type
        {
            get { return this.GetEnum<InquiryType>(1, 1); }
            set { this.SetEnum<InquiryType>(value, 1, 1); }
        }
        public DetailType LargeData
        {
            get { return this.GetEnum<DetailType>(2, 1); }
            set { this.SetEnum<DetailType>(value, 2, 1); }
        }
        ///  <summary>
        /// Danish: FEJLNR
        ///  </summary>
        public string ErrorNumber
        {
            get { return this.GetString(3, 2); }
            set { this.SetString(value, 3, 2); }
        }
        public string PNR
        {
            get { return this.GetString(5, 10); }
            set { this.SetString(value, 5, 10); }
        }
        public string Data
        {
            get { return this.GetString(15, 222); }
            set { this.SetString(value, 15, 222); }
        }

        #endregion

    }

  
    public partial class ClassicResponseBasicDataType: Wrapper
    {
        #region Common

        public override int Length
        {
            get { return 0; }
        }
        #endregion

        #region Properties

        public string PNR
        {
            get { return this.GetString(1, 10); }
            set { this.SetString(value, 1, 10); }
        }
        ///  <summary>
        /// Danish: EFTERNVN
        ///  </summary>
        public string LastName
        {
            get { return this.GetString(11, 40); }
            set { this.SetString(value, 11, 40); }
        }
        ///  <summary>
        /// Danish: FORNVN
        ///  </summary>
        public string FirstAndMiddleNames
        {
            get { return this.GetString(51, 50); }
            set { this.SetString(value, 51, 50); }
        }
        ///  <summary>
        /// De første 4 karakterer er: C/O og en blank
        ///  </summary>
        public string CareOfName
        {
            get { return this.GetString(101, 34); }
            set { this.SetString(value, 101, 34); }
        }
        public string StreetName
        {
            get { return this.GetString(135, 40); }
            set { this.SetString(value, 135, 40); }
        }
        ///  <summary>
        /// husnummer 3 karakterer, og husbogstav, 1 karakter.
        ///  </summary>
        public string HouseNumber
        {
            get { return this.GetString(175, 4); }
            set { this.SetString(value, 175, 4); }
        }
        public string Floor
        {
            get { return this.GetString(179, 2); }
            set { this.SetString(value, 179, 2); }
        }
        public string Door
        {
            get { return this.GetString(181, 4); }
            set { this.SetString(value, 181, 4); }
        }
        public string BNR
        {
            get { return this.GetString(185, 4); }
            set { this.SetString(value, 185, 4); }
        }
        public string PostCode
        {
            get { return this.GetString(189, 4); }
            set { this.SetString(value, 189, 4); }
        }
        public string PostDistrict
        {
            get { return this.GetString(193, 20); }
            set { this.SetString(value, 193, 20); }
        }
        ///  <summary>
        /// Day, month, century, year
        ///  </summary>
        public DateTime? AddressProtectionDate
        {
            get { return this.GetDateTime(213, 8, "ddMMyyyy"); }
            set { this.SetDateTime(value, 213, 8, "ddMMyyyy"); }
        }
        public string StatusCode
        {
            get { return this.GetString(221, 2); }
            set { this.SetString(value, 221, 2); }
        }

        #endregion

    }

  
    public partial class NewRquestType: ClassicRequestType
    {
        #region Common

        public override int Length
        {
            get { return 40; }
        }
        #endregion

        #region Properties

        ///  <summary>
        /// Always contains 'MMXIII', IE. Roman numeral for 2013, where the new solution came into operation
        ///  </summary>
        public string NewType
        {
            get { return this.GetString(13, 6); }
            set { this.SetString(value, 13, 6); }
        }
        ///  <summary>
        /// Calls to the DPR forwarding enforced on to CPR Directly in all cases regardless of the application's lookup-check for invalid markup, PNR or uncertainty '1 0' call.
        ///  </summary>
        public decimal ForceDiversion
        {
            get { return this.GetDecimal(19, 1); }
            set { this.SetDecimal(value, 19, 1); }
        }
        public decimal ReponseData
        {
            get { return this.GetDecimal(20, 1); }
            set { this.SetDecimal(value, 20, 1); }
        }
        ///  <summary>
        /// End user's user ID or possibly. fagsystemet system user ID.
        ///  </summary>
        public string UserID
        {
            get { return this.GetString(21, 20); }
            set { this.SetString(value, 21, 20); }
        }

        #endregion

    }

  
    }
  