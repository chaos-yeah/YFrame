using System;
using Dos.ORM;

namespace YFrame.Model
{
    [Serializable]
	public partial class Student : Entity
    {

		public Student() : base("Student") { }

	    #region Field
        private int _Id;
	    /// <summary>
        /// auto_inrement
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
        private string _No;
	    /// <summary>
        /// 
        /// </summary>
        public string No
        {
            get { return _No; }
            set
            {
                this.OnPropertyValueChange(_.No, _No, value);
                this._No = value;
                
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
            return new Field[] { _.Id, _.No, _.Name };
        }

        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
            return new object[] { this._Id, this._No, this._Name };
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
            public readonly static Field All = new Field("*", "Student");

			/// <summary>
            /// auto_inrement
            /// </summary>
            public readonly static Field Id = new Field("Id", "Student", "auto_inrement");

			/// <summary>
            /// 
            /// </summary>
            public readonly static Field No = new Field("No", "Student", "");

			/// <summary>
            /// 
            /// </summary>
            public readonly static Field Name = new Field("Name", "Student", "");

			
        }
		#endregion
        
    }

}
