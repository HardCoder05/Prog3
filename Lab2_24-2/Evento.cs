using System;
using System.Collections.Generic;

public abstract class Evento : InfoProvider, IDataProvider{
	protected static int correlativo = 1; 
	protected int identificador; 
	protected string nombre; 
	protected double costoRealizacion; 
	protected char tipoPublico; 
	public Local Local; 				 
	protected List<Funcion> funciones; 
	protected List<Artista> artistas;
	
	public Evento(string nombre, Double costoRealizacion, char tipoPublico){
		this.identificador = correlativo; 
		this.nombre = nombre;
		this.costoRealizacion = costoRealizacion;
		this.tipoPublico = tipoPublico;
		
		funciones = new List<Funcion>();
		artistas = new List<Artista>(); 
		correlativo++; 
	}
	
	public void setLocal(Local local){
		this.Local = local; 
	}
	
	public void agregarFuncion(Funcion func){
		funciones.Add(func); 
	}
	
	public void agregarArtista(Artista artista){
		artistas.Add(artista); 
	}
	
	public string linea(){
		return "-------------------------------------------------\n";
	}
	
	public string infoArtistas(){
		int id = 1; 
		string cad="";
		foreach(Artista ar in artistas){
			cad += "ARTISTA " + id +  ": ";
			cad += ar.devolverDatos(); 
			id++;
		}	

		return cad; 
	}
	
	public string infoFunciones(){
		int id = 1;
		string cad="";
		foreach(Funcion fun in funciones){
			cad += "FUNCION " + id +  ": ";
			cad += fun.devolverDatos(); 
			id++;
		}	
		return cad; 
	}
	
	public abstract string infoReq();
	
	public string devolverDatos(){
		return devolverCabecera();
	}
	
	public virtual string devolverCabecera(){ //virtual para que pueda ser sobreescrito
		return "EVENTO Nro. " +identificador+"\n"+linea()
				+ "NOMBRE: " + nombre  + " - TIPO DE PUBLICO: " + tipoPublico+"\n" 
				+ infoArtistas() + Local.devolverDatos()
				+ infoFunciones();
	}
}
