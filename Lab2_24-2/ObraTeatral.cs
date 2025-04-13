
public class ObraTeatral : Evento{
	private int numeroActosObra;
	private bool requiereEscenografia;
	
	public ObraTeatral(string nombre, double costoRealizacion, char tipoPublico,
				int numeroActosObra, bool requiereEscenografia) : base(nombre,costoRealizacion,tipoPublico){
		this.numeroActosObra = numeroActosObra;
		this.requiereEscenografia = requiereEscenografia;
	}
	
	public override string infoReq(){
		return requiereEscenografia == true ? "SI" : "NO"; 
	}
	
	public override string devolverCabecera(){
		return base.devolverCabecera() + "OBRA TEATRAL - NUM. ACTOS: "
			+ numeroActosObra + "\nREQ. ESCENOGRAFIA: " + infoReq() + "\n" +
			base.linea();
	}
	
	
}