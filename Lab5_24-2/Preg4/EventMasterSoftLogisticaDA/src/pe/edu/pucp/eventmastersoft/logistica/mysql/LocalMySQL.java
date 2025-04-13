package pe.edu.pucp.eventmastersoft.logistica.mysql;
import pe.edu.pucp.eventmastersoft.config.DBManager;
import pe.edu.pucp.eventmastersoft.logistica.dao.LocalDAO;

import java.sql.PreparedStatement;
import java.sql.Connection; 
import pe.edu.pucp.eventmastersoft.logistica.model.Local;

public class LocalMySQL implements LocalDAO{
    private PreparedStatement pst;
    private Connection con;
    private String sql;
    
    @Override
    public int insertar(Local local) {
        int resultado = 0;
        
        try{
            con = DBManager.getInstance().getConnection();
            
            sql = "INSERT INTO local(nombre,direccion,capacidad"
                    + ",espacio_m2,tipo_local,activo) "
                    + "VALUES(?,?,?,?,?,1)"; 
            
            pst = con.prepareStatement(sql);
            
            pst.setString(1, local.getNombre());
            pst.setString(2, local.getDireccion());
            pst.setInt(3, local.getCapacidad());
            pst.setDouble(4, local.getEspacioMetrosCuadrados());
            //pst.setString(5, local.getTipoLocal().toString());
            pst.setString(5, local.getTipoLocal().name());
            
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
