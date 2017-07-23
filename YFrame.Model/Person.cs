using System;
using Dos.ORM;

namespace YFrame.Model
{
    [Serializable]
	public partial class Person : Entity
    {

		public Person() : base("Person") { }

	    #region Field
        private int _Id;
	    /// <summary>
        /// auto_increment
        /// </summary>
        public int Id
        {
            get { return _Id; }
            set
            {
                this.OnPropertyValueChange(_.Id, _Id, value);
                this._Id = value;
                
            }
        }
        private string _Name;
	    /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set
            {
                this.OnPropertyValueChange(_.Name, _Name, value);
                this._Name = value;
                
            }
        }
        private string _Sex;
	    /// <summary>
        /// 
        /// </summary>
        public string Sex
        {
            get { return _Sex; }
            set
            {
                this.OnPropertyValueChange(_.Sex, _Sex, value);
                this._Sex = value;
                
            }
        }
        private int _Age;
	    /// <summary>
        /// 
        /// </summary>
        public int Age
        {
            get { return _Age; }
            set
            {
                this.OnPropertyValueChange(_.Age, _Age, value);
                this._Age = value;
                
            }
        }
        private DateTime _Datetime;
	    /// <summary>
        /// 
        /// </summary>
        public DateTime Datetime
        {
            get { return _Datetime; }
            set
            {
                this.OnPropertyValueChange(_.Datetime, _Datetime, value);
                this._Datetime = value;
                
            }
        }
		#endregion

		#region Method
        /// <summary>
        /// 获取实体中的标识列
        /// </summary>
        public override Field GetIdentityField()
        {
            return _.Id;
        }
        /// <summary>
        /// 获取实体中的主键列
        /// </summary>
        public override Field[] GetPrimaryKeyFields()
        {
            return new Field[] { _.Id };
        }
		/// <summary>
        /// 获取列信息
        /// </summary>
        public override Field[] GetFields()
        {
            return new Field[] { _.Id, _.Name, _.Sex, _.Age, _.Datetime };
        }

        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
            return new object[] { this._Id, this._Name, this._Sex, this._Age, this._Datetime };
        }
		#endregion
		
		#region _
        /// <summary>
        /// 字段信息
        /// </summary>
        public class _
        {
            /// <summary>
            /// *
            /// </summary>
            public readonly static Field All = new Field("*", "Person");

			/// <summary>
            /// auto_increment
            /// </summary>
            public readonly static Field Id = new Field("Id", "Person", "auto_increment");

			/// <summary>
            /// 
            /// </summary>
            public readonly static Field Name = new Field("Name", "Person", "");

			/// <summary>
            /// 
            /// </summary>
            public readonly static Field Sex = new Field("Sex", "Person", "");

			/// <summary>
            /// 
            /// </summary>
            public readonly static Field Age = new Field("Age", "Person", "");

			/// <summary>
            /// 
            /// </summary>
            public readonly static Field Datetime = new Field("Datetime", "Person", "");

			
        }
		#endregion
        
    }

}
