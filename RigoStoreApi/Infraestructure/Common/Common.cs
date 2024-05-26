using Azure;
using Domain.Entities;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Extensions.Configuration;


namespace Infraestructure.Common
{
    public class Common
    {
        private readonly ObjResponse _response;
        private readonly IConfiguration _config;
      
        public Common(ObjResponse response, IConfiguration config) 
        { 
            _response = response;
            _config = config;
        }

        public async Task<ObjResponse> GetBadResponse()
        {
            _response.Message = "Bad Request";
            _response.StatusCode = HttpStatusCode.BadRequest;
            _response.Code = 400;
            return await Task.FromResult(_response);
        }

        public async Task<ObjResponse> GetGoodResponse()
        {
            _response.StatusCode = HttpStatusCode.OK;
            _response.Code = 200;
            return await Task.FromResult(_response);
        }

        public SqlConnection Conectar()
        {        
            SqlConnection con = new SqlConnection(_config.GetConnectionString("conexionSql"));
            if (con.State == ConnectionState.Closed) 
            { 
                con.Open();
            }
            return con;
        }

    }
}
