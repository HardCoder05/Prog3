using System;
using System.Collections.Generic;

public class Artista : InfoProvider{
    private string nombre; 
	private string nacionalidad; 
	private List <Artista> artistas;
	
	public Artista(String nombre, String nacionalidad){
		this.nombre = nombre; 
		this.nacionalidad = nacionalidad;  
		artistas = new List<Artista>(); 
	}
	
	public void agregarArtista(Artista artInt1){
		artistas.Add(artInt1);
	}
	
	public string devolverDatos(){
		return "ARTISTA: " + this.nombre +  "\n";
	}

}