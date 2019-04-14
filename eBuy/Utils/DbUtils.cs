﻿using Dapper;
using eBuy.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace eBuy.Utils
{
    public static class DbUtils
    {
        private static SqlConnection OpenConnection()
        {
            string constr = ConfigurationManager.ConnectionStrings["eBuy"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            return con;
        }

        // TODO: should i move this into a helper?
        public static List<Product> GetAllProducts()
        {
            using (IDbConnection db = OpenConnection())
            {
                return db.Query<Product>
                ("Select * From Product").ToList();
            }
        }
    }
}