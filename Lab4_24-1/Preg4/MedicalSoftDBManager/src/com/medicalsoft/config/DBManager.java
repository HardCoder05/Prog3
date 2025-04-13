package com.medicalsoft.config;

import java.sql.DriverManager;
import java.sql.Connection;

public class DBManager {
    
    private Connection con;
    private static DBManager dbManager;
    private final String url = "jdbc:mysql://" + ""
            + "prog3-labs-1inf30.ct8ec2g04pnq.us-east-1.rds.amazonaws.com"
            + ":3306/" + "laboratorio4"; 
    private final String username = "admin";
    private final String password = "labs1inf3020245";
    
    public Connection getConnection(){
        try{
            Class.forName("com.mysql.cj.jdbc.Driver");
            con = DriverManager.getConnection(url, username, password);     
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return con;
    }
    
    public static DBManager getInstance(){
        if(dbManager == null){
            createInstance();
        }
        return dbManager;
    }
    
    private synchronized static void createInstance(){
        if(dbManager == null){
            dbManager = new DBManager();
        }
    }
}