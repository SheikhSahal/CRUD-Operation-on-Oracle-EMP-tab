using Oracle_query.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;

namespace Oracle_query.ModelView.Home
{
    public class EMPModelView
    {
        string oradb = "Data Source=dbtest;User ID=psl;Password=psl;";


        public List<EMP> GEtdb()
        {
            List<EMP> DBase = new List<EMP>();

            OracleConnection con = new OracleConnection(oradb);
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "Select * from emp";
            cmd.Connection = con;
            con.Open();

            OracleDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                EMP emp = new EMP();



                emp.EMPNO = Convert.ToInt16(reader["EMPNO"]);
                emp.ENAME = reader["ENAME"].ToString();
                emp.JOB = reader["JOB"].ToString();

                if (reader["MGR"] != DBNull.Value)
                {
                    emp.MGR = Convert.ToInt16(reader["MGR"]);
                }

                if (reader["HIREDATE"] != DBNull.Value)
                {
                    emp.HIREDATE = Convert.ToDateTime(reader["HIREDATE"]);
                }

                if (reader["SAL"] != DBNull.Value)
                {
                    emp.SAL = Convert.ToInt16(reader["SAL"]);
                }

                if (reader["COMM"] != DBNull.Value)
                {
                    emp.COMM = Convert.ToInt16(reader["COMM"]);
                }

                if (reader["DEPTNO"] != DBNull.Value)
                {
                    emp.DEPTNO = Convert.ToInt16(reader["DEPTNO"]);
                }


                DBase.Add(emp);

            }


            return DBase;
        }

        public void AddNewEmployee(EMP emp)
        {
            OracleConnection con = new OracleConnection(oradb);
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "insert into emp values(:empno,:ename,:job,:mgr,:hiredate,:sal,:comm,:deptno)";
            cmd.Connection = con;
            con.Open();

            cmd.Parameters.Add(new OracleParameter("empno", emp.EMPNO));
            cmd.Parameters.Add(new OracleParameter("ename", emp.ENAME));
            cmd.Parameters.Add(new OracleParameter("job", emp.JOB));
            cmd.Parameters.Add(new OracleParameter("mgr", emp.MGR));
            cmd.Parameters.Add(new OracleParameter("hiredate", emp.HIREDATE));
            cmd.Parameters.Add(new OracleParameter("sal", emp.SAL));
            cmd.Parameters.Add(new OracleParameter("comm", emp.COMM));
            cmd.Parameters.Add(new OracleParameter("deptno", emp.DEPTNO));


            cmd.ExecuteNonQuery();
        }


        public EMP EmployeeDetails(int id)
        {
            EMP employee = new EMP();
            OracleConnection con = new OracleConnection(oradb);
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "select * from emp where empno = :empno";
            cmd.Connection = con;
            con.Open();

            cmd.Parameters.Add(new OracleParameter("empno", id));
            OracleDataReader reader = cmd.ExecuteReader();

            reader.Read();

            employee.EMPNO = Convert.ToInt16(reader["EMPNO"]);
            employee.ENAME = reader["ENAME"].ToString();
            employee.JOB = reader["JOB"].ToString();

            if (reader["MGR"] != DBNull.Value)
            {
                employee.MGR = Convert.ToInt16(reader["MGR"]);
            }

            if (reader["HIREDATE"] != DBNull.Value)
            {
                employee.HIREDATE = Convert.ToDateTime(reader["HIREDATE"]);
            }

            if (reader["SAL"] != DBNull.Value)
            {
                employee.SAL = Convert.ToInt16(reader["SAL"]);
            }


            if (reader["COMM"] != DBNull.Value)
            {
                employee.COMM = Convert.ToInt16(reader["COMM"]);
            }

            if (reader["DEPTNO"] != DBNull.Value)
            {
                employee.DEPTNO = Convert.ToInt16(reader["DEPTNO"]);
            }



            return employee;
        }


        public void updateemp(EMP emp)
        {

            OracleConnection con = new OracleConnection(oradb);
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "update emp set ename = :ename,job = :job , mgr = :mgr, hiredate= :hiredate,sal = :sal,comm = :comm,deptno = :deptno  where empno = :empno";
            cmd.Connection = con;
            con.Open();

            cmd.Parameters.Add(new OracleParameter("ename", emp.ENAME));
            cmd.Parameters.Add(new OracleParameter("job", emp.JOB));
            cmd.Parameters.Add(new OracleParameter("mgr", emp.MGR));
            cmd.Parameters.Add(new OracleParameter("hiredate", emp.HIREDATE));
            cmd.Parameters.Add(new OracleParameter("sal", emp.SAL));
            cmd.Parameters.Add(new OracleParameter("comm", emp.COMM));
            cmd.Parameters.Add(new OracleParameter("deptno", emp.DEPTNO));
            cmd.Parameters.Add(new OracleParameter("empno", emp.EMPNO));
            cmd.ExecuteNonQuery();
        }

        public void Getdelete(int id)
        {
            OracleConnection con = new OracleConnection(oradb);
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "delete from emp where empno = :empno";
            cmd.Connection = con;
            con.Open();

            cmd.Parameters.Add(new OracleParameter("empno",id));

            cmd.ExecuteNonQuery();

        }

        public EMP AutoGenerate()
        {
            EMP employee = new EMP();
            OracleConnection con = new OracleConnection(oradb);
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "Select max(nvl(empno,0))+1 as auto From emp";
            cmd.Connection = con;
            con.Open();

            
            OracleDataReader reader = cmd.ExecuteReader();

            reader.Read();

            employee.EMPNO = Convert.ToInt16(reader["auto"]);

            reader.Close();
            return employee;
        }

    }
}