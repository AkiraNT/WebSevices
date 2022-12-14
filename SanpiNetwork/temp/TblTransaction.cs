using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;
// <auto-generated />
namespace SweetCMS.DataAccess
{
	/// <summary>
	/// Strongly-typed collection for the TblTransaction class.
	/// </summary>
    [Serializable]
	public partial class TblTransactionCollection : ActiveList<TblTransaction, TblTransactionCollection>
	{	   
		public TblTransactionCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblTransactionCollection</returns>
		public TblTransactionCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblTransaction o = this[i];
                foreach (SubSonic.Where w in this.wheres)
                {
                    bool remove = false;
                    System.Reflection.PropertyInfo pi = o.GetType().GetProperty(w.ColumnName);
                    if (pi.CanRead)
                    {
                        object val = pi.GetValue(o, null);
                        switch (w.Comparison)
                        {
                            case SubSonic.Comparison.Equals:
                                if (!val.Equals(w.ParameterValue))
                                {
                                    remove = true;
                                }
                                break;
                        }
                    }
                    if (remove)
                    {
                        this.Remove(o);
                        break;
                    }
                }
            }
            return this;
        }
		
		
	}
	/// <summary>
	/// This is an ActiveRecord class which wraps the TblTransactions table.
	/// </summary>
	[Serializable]
	public partial class TblTransaction : ActiveRecord<TblTransaction>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblTransaction()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblTransaction(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblTransaction(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblTransaction(string columnName, object columnValue)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByParam(columnName,columnValue);
		}
		
		protected static void SetSQLProps() { GetTableSchema(); }
		
		#endregion
		
		#region Schema and Query Accessor	
		public static Query CreateQuery() { return new Query(Schema); }
		public static TableSchema.Table Schema
		{
			get
			{
				if (BaseSchema == null)
					SetSQLProps();
				return BaseSchema;
			}
		}
		
		private static void GetTableSchema() 
		{
			if(!IsSchemaInitialized)
			{
				//Schema declaration
				TableSchema.Table schema = new TableSchema.Table("TblTransactions", TableType.Table, DataService.GetInstance("DataAcessProvider"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "Id";
				colvarId.DataType = DbType.Int32;
				colvarId.MaxLength = 0;
				colvarId.AutoIncrement = true;
				colvarId.IsNullable = false;
				colvarId.IsPrimaryKey = true;
				colvarId.IsForeignKey = false;
				colvarId.IsReadOnly = false;
				colvarId.DefaultSetting = @"";
				colvarId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarId);
				
				TableSchema.TableColumn colvarAccountId = new TableSchema.TableColumn(schema);
				colvarAccountId.ColumnName = "AccountId";
				colvarAccountId.DataType = DbType.Int32;
				colvarAccountId.MaxLength = 0;
				colvarAccountId.AutoIncrement = false;
				colvarAccountId.IsNullable = false;
				colvarAccountId.IsPrimaryKey = false;
				colvarAccountId.IsForeignKey = false;
				colvarAccountId.IsReadOnly = false;
				
						colvarAccountId.DefaultSetting = @"((0))";
				colvarAccountId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAccountId);
				
				TableSchema.TableColumn colvarCode = new TableSchema.TableColumn(schema);
				colvarCode.ColumnName = "Code";
				colvarCode.DataType = DbType.AnsiString;
				colvarCode.MaxLength = 50;
				colvarCode.AutoIncrement = false;
				colvarCode.IsNullable = false;
				colvarCode.IsPrimaryKey = false;
				colvarCode.IsForeignKey = false;
				colvarCode.IsReadOnly = false;
				
						colvarCode.DefaultSetting = @"('')";
				colvarCode.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCode);
				
				TableSchema.TableColumn colvarQty = new TableSchema.TableColumn(schema);
				colvarQty.ColumnName = "Qty";
				colvarQty.DataType = DbType.Decimal;
				colvarQty.MaxLength = 0;
				colvarQty.AutoIncrement = false;
				colvarQty.IsNullable = false;
				colvarQty.IsPrimaryKey = false;
				colvarQty.IsForeignKey = false;
				colvarQty.IsReadOnly = false;
				
						colvarQty.DefaultSetting = @"((0))";
				colvarQty.ForeignKeyTableName = "";
				schema.Columns.Add(colvarQty);
				
				TableSchema.TableColumn colvarRate = new TableSchema.TableColumn(schema);
				colvarRate.ColumnName = "Rate";
				colvarRate.DataType = DbType.Decimal;
				colvarRate.MaxLength = 0;
				colvarRate.AutoIncrement = false;
				colvarRate.IsNullable = false;
				colvarRate.IsPrimaryKey = false;
				colvarRate.IsForeignKey = false;
				colvarRate.IsReadOnly = false;
				
						colvarRate.DefaultSetting = @"((0))";
				colvarRate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRate);
				
				TableSchema.TableColumn colvarAmount = new TableSchema.TableColumn(schema);
				colvarAmount.ColumnName = "Amount";
				colvarAmount.DataType = DbType.Decimal;
				colvarAmount.MaxLength = 0;
				colvarAmount.AutoIncrement = false;
				colvarAmount.IsNullable = false;
				colvarAmount.IsPrimaryKey = false;
				colvarAmount.IsForeignKey = false;
				colvarAmount.IsReadOnly = false;
				
						colvarAmount.DefaultSetting = @"((0))";
				colvarAmount.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAmount);
				
				TableSchema.TableColumn colvarType = new TableSchema.TableColumn(schema);
				colvarType.ColumnName = "Type";
				colvarType.DataType = DbType.AnsiString;
				colvarType.MaxLength = 20;
				colvarType.AutoIncrement = false;
				colvarType.IsNullable = false;
				colvarType.IsPrimaryKey = false;
				colvarType.IsForeignKey = false;
				colvarType.IsReadOnly = false;
				
						colvarType.DefaultSetting = @"('')";
				colvarType.ForeignKeyTableName = "";
				schema.Columns.Add(colvarType);
				
				TableSchema.TableColumn colvarStatus = new TableSchema.TableColumn(schema);
				colvarStatus.ColumnName = "Status";
				colvarStatus.DataType = DbType.AnsiString;
				colvarStatus.MaxLength = 50;
				colvarStatus.AutoIncrement = false;
				colvarStatus.IsNullable = false;
				colvarStatus.IsPrimaryKey = false;
				colvarStatus.IsForeignKey = false;
				colvarStatus.IsReadOnly = false;
				
						colvarStatus.DefaultSetting = @"('')";
				colvarStatus.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStatus);
				
				TableSchema.TableColumn colvarDateX = new TableSchema.TableColumn(schema);
				colvarDateX.ColumnName = "Date";
				colvarDateX.DataType = DbType.DateTime;
				colvarDateX.MaxLength = 0;
				colvarDateX.AutoIncrement = false;
				colvarDateX.IsNullable = false;
				colvarDateX.IsPrimaryKey = false;
				colvarDateX.IsForeignKey = false;
				colvarDateX.IsReadOnly = false;
				
						colvarDateX.DefaultSetting = @"(getdate())";
				colvarDateX.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDateX);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["DataAcessProvider"].AddSchema("TblTransactions",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Id")]
		[Bindable(true)]
		public int Id 
		{
			get { return GetColumnValue<int>(Columns.Id); }
			set { SetColumnValue(Columns.Id, value); }
		}
		  
		[XmlAttribute("AccountId")]
		[Bindable(true)]
		public int AccountId 
		{
			get { return GetColumnValue<int>(Columns.AccountId); }
			set { SetColumnValue(Columns.AccountId, value); }
		}
		  
		[XmlAttribute("Code")]
		[Bindable(true)]
		public string Code 
		{
			get { return GetColumnValue<string>(Columns.Code); }
			set { SetColumnValue(Columns.Code, value); }
		}
		  
		[XmlAttribute("Qty")]
		[Bindable(true)]
		public decimal Qty 
		{
			get { return GetColumnValue<decimal>(Columns.Qty); }
			set { SetColumnValue(Columns.Qty, value); }
		}
		  
		[XmlAttribute("Rate")]
		[Bindable(true)]
		public decimal Rate 
		{
			get { return GetColumnValue<decimal>(Columns.Rate); }
			set { SetColumnValue(Columns.Rate, value); }
		}
		  
		[XmlAttribute("Amount")]
		[Bindable(true)]
		public decimal Amount 
		{
			get { return GetColumnValue<decimal>(Columns.Amount); }
			set { SetColumnValue(Columns.Amount, value); }
		}
		  
		[XmlAttribute("Type")]
		[Bindable(true)]
		public string Type 
		{
			get { return GetColumnValue<string>(Columns.Type); }
			set { SetColumnValue(Columns.Type, value); }
		}
		  
		[XmlAttribute("Status")]
		[Bindable(true)]
		public string Status 
		{
			get { return GetColumnValue<string>(Columns.Status); }
			set { SetColumnValue(Columns.Status, value); }
		}
		  
		[XmlAttribute("DateX")]
		[Bindable(true)]
		public DateTime DateX 
		{
			get { return GetColumnValue<DateTime>(Columns.DateX); }
			set { SetColumnValue(Columns.DateX, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varAccountId,string varCode,decimal varQty,decimal varRate,decimal varAmount,string varType,string varStatus,DateTime varDateX)
		{
			TblTransaction item = new TblTransaction();
			
			item.AccountId = varAccountId;
			
			item.Code = varCode;
			
			item.Qty = varQty;
			
			item.Rate = varRate;
			
			item.Amount = varAmount;
			
			item.Type = varType;
			
			item.Status = varStatus;
			
			item.DateX = varDateX;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int varAccountId,string varCode,decimal varQty,decimal varRate,decimal varAmount,string varType,string varStatus,DateTime varDateX)
		{
			TblTransaction item = new TblTransaction();
			
				item.Id = varId;
			
				item.AccountId = varAccountId;
			
				item.Code = varCode;
			
				item.Qty = varQty;
			
				item.Rate = varRate;
			
				item.Amount = varAmount;
			
				item.Type = varType;
			
				item.Status = varStatus;
			
				item.DateX = varDateX;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn AccountIdColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn CodeColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn QtyColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn RateColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn AmountColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn TypeColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn StatusColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn DateXColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"Id";
			 public static string AccountId = @"AccountId";
			 public static string Code = @"Code";
			 public static string Qty = @"Qty";
			 public static string Rate = @"Rate";
			 public static string Amount = @"Amount";
			 public static string Type = @"Type";
			 public static string Status = @"Status";
			 public static string DateX = @"Date";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
