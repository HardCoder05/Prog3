
public class Concierto : Evento{
	private TipoConcierto tipoCon;
	private bool permisoGrabar;
	
	public Concierto(string nombre, double costoRealizacion, char tipoPublico,
				TipoConcierto tipoCon, bool permisoGrabar) : base(nombre,costoRealizacion,tipoPublico){
		this.tipoCon = tipoCon;
		this.permisoGrabar = permisoGrabar;
	}
	
	public override string infoReq(){
		return permisoGrabar == true ? "SI" : "NO"; 
	}

	public override string devolverCabecera(){
		return base.devolverCabecera() + "CONCIERTO - TIPO: "
			+ tipoCon + "\nPERMISO GRABACION: " + infoReq() + "\n" +
			base.linea();
	}
	
}