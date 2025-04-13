package com.medicalsoft.infraestructura.mysql;
import com.medicalsoft.config.DBManager;
import com.medicalsoft.infraestructura.dao.SalaEspecializadaDAO;
import com.medicalsoft.infraestructura.model.SalaEspecializada;

import java.sql.Connection;
import java.sql.PreparedStatement; 

public class SalaEspecializadaMySQL implements SalaEspecializadaDAO{
    //sentencia SQL precompilada -> para ej la inserción de datos
    private PreparedStatement pst;
    //private Statement st; 
    private Connection con;
    private String sql;
    
    @Override
    public int insertar(SalaEspecializada salaEspecializada) {
        //Implemente el método de registro de una sala especializada
        int resultado = 0;
        
        try{
            //Creamos la conexion de bd
            con = DBManager.getInstance().getConnection();
            
            //sentencia sql 
            sql = "INSERT INTO sala_especializada(nombre,espacio_en_m2,torre"
                    + ",piso,posee_equipamiento_imagenologia,activa) "
                    + "VALUES(?,?,?,?,?,1)";
            
            //prepara el statement
            pst = con.prepareStatement(sql);
            //llena los valores que fueron puestos como ? 
            pst.setString(1, salaEspecializada.getNombre());
            pst.setDouble(2, salaEspecializada.getEspacioEnMetrosCuadrados());
            pst.setString(3, String.valueOf(salaEspecializada.getTorre()));
            pst.setInt(4, salaEspecializada.getPiso());
            pst.setBoolean(5, salaEspecializada.isPoseeEquipamientoImagenologia());
            resultado = pst.executeUpdate();
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        finally{
            try{
                con.close();
            }catch(Exception ex){
                System.out.println(ex.getMessage());
            }
        }
        
        return resultado;
    }
    
}
