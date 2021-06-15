using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Attributes;
using MISA.BL.Exceptions;
using MISA.BL.Interfaces;
using MISA.DL;
using MISA.DL.Interfaces;

namespace MISA.BL
{
    public class BaseBL<MISAEntity>:IBaseBL<MISAEntity>
    {
        IBaseDL _baseDL;

        public BaseBL(IBaseDL baseDL)
        {
            _baseDL = baseDL;
        }
        public IEnumerable<MISAEntity> GetAll()
        {
            return _baseDL.GetAll<MISAEntity>();
        }

        public MISAEntity GetById(Guid entityId)
        {
            return _baseDL.GetById<MISAEntity>(entityId);
        }

        public int Insert(MISAEntity entity)
        {
            // validate dữ liệu:
            Validate(entity);
            return _baseDL.Insert<MISAEntity>(entity);
        }

        public int Update(MISAEntity entity, Guid entityId)
        {
            return _baseDL.Update<MISAEntity>(entity, entityId);
        }

        public int Delete(Guid entityId)
        {
            return _baseDL.Delete<MISAEntity>(entityId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="MISAEntity"></typeparam>
        /// <param name="entity"></param>
        protected virtual void Validate(MISAEntity entity)
        {
            var properties = typeof(MISAEntity).GetProperties();
            foreach (var property in properties)
            {
                var attributeRequireds = property.GetCustomAttributes(typeof(MISARequired), true);
                var attributeMaxLength = property.GetCustomAttributes(typeof(MISAMaxLength), true);
                if (attributeRequireds.Length > 0)
                {
                    var propertyValue = property.GetValue(entity);
                    var propertyType = property.PropertyType;
                    if (property.PropertyType == typeof(string) && string.IsNullOrEmpty(propertyValue.ToString()))
                    {
                        var msgError = (attributeRequireds[0] as MISARequired).MsgError;
                        throw new GuardException<MISAEntity>($"{msgError} không được phép để trống", entity);
                    }
                }

                if (attributeMaxLength.Length > 0)
                {
                    var propertyValue = property.GetValue(entity);
                    
                    var maxLength = (attributeMaxLength[0] as MISAMaxLength).MaxLength;
                    var propertyName = (attributeMaxLength[0] as MISAMaxLength).MsgError;
                    if (propertyValue.ToString().Length > maxLength)
                    {
                        throw new GuardException<MISAEntity>($"Trường thông tin {propertyName} không được dài quá {maxLength} ký tự", entity);
                    }    
                }    
            }
        }
    }
}
