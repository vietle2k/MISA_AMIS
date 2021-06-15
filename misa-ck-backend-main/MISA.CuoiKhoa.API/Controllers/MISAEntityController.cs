﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MISA.BL;
using MISA.BL.Exceptions;
using MISA.BL.Interfaces;

namespace MISA.CuoiKhoa.API.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class MISAEntityController<MISAEntity> : ControllerBase
    {
        IBaseBL<MISAEntity> _baseBL;

        public MISAEntityController(IBaseBL<MISAEntity> baseBL)
        {
            _baseBL = baseBL;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var entities = _baseBL.GetAll();
            //   Kiểm tra dữ liệu và trả về cho Client
            // - Nếu có dữ liệu thì trả về 200 kèm theo dữ liệu
            // - Không có dữ liệu thì trả về 204:
            if (entities.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(entities);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var entity = _baseBL.GetById(id);
            // 4. Trả về cho Client:
            if (entity != null)
            {
                return Ok(entity);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] MISAEntity entity)
        {
            try
            {
                var rowAffects = _baseBL.Insert(entity);
                // 4. Trả về cho Client:
                if (rowAffects > 0)
                {
                    return StatusCode(201, rowAffects);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (GuardException<MISAEntity> ex)
            {
                var mes = new
                {
                    devMsg = ex.Message,
                    userMsg = "Dữ liệu không hợp lệ, vui lòng kiểm tra lại!",
                    field = "CustomerCode",
                    data = ex.Data
                };
                return StatusCode(400, mes);
            }
            catch (Exception ex)
            {

                var mes = new
                {
                    devMsg = ex.Message,
                    userMsg = "Có lỗi xảy ra, vui lòng liên hệ MISA để được trợ giúp",
                    field = "CustomerCode"
                };
                return StatusCode(500, mes);
            }

        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] MISAEntity entity)
        {
            var res = _baseBL.Update(entity, id);
            if (res > 0)
            {
                return StatusCode(200, "Sửa thông tin thành công");
            }
            else
            {
                return NoContent();
            }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var rowAffects = _baseBL.Delete(id);
            if (rowAffects > 0)
            {
                return StatusCode(200, "Xóa thành công");
            }
            else
            {
                return NoContent();
            }
        }
    }
}
