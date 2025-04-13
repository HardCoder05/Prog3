using System; 
using System.Collections.Generic;

public class Productora{
	private string nombre; 
	private List<Evento> eventos;
	
	public Productora(string nombre){
		this.nombre = nombre; 
		eventos = new List<Evento>(); 
	}
	
	public void agregarEvento(Evento evento){
		eventos.Add(evento);
	}
	
	public string consultarDatosEvento(int indice){
        if(indice < 0 || indice >= eventos.Count){
            return "No existe el evento";
        }
        else{
            return eventos[indice].devolverDatos();
        }
	}
	
	public string consultarObrasTeatrales(){
		string cad="";

		foreach(Evento ev in eventos){
			if(ev is ObraTeatral){
				cad += ev.devolverDatos();
			}
		}
		
		return cad; 
	}
	
}