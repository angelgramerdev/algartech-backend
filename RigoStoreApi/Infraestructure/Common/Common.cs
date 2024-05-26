﻿using Azure;
using Domain.Entities;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace Infraestructure.Common
{
    public class Common
    {
        private readonly ObjResponse _response;
      
        public Common(ObjResponse response) 
        { 
            _response = response;   
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
            string datosConneccion = "Server=DESKTOP-BVDLDCJ\\SQLEXPRESS;Database=dbrigostore;User ID=sa;Password=1234;Trusted_Connection=true;MultipleActiveResultSets=true";
            SqlConnection con = new SqlConnection(datosConneccion);
            if (con.State == ConnectionState.Closed) 
            { 
                con.Open();
            }
            return con;
        }

    }
}