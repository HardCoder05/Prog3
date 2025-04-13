using System.Collections.Generic;
using System;

class Principal{
	public static void Main(string[] args){
		//Creamos la institucion educativa
		InstitucionEducativa ie1 = new InstitucionEducativa(1,"1092828764","Intelectuales SAC");

		//Creamos una sede
		Sede sede1 = new Sede(1,"Intelectuales SAC San Miguel","Av. Universitaria 1801");

		//Inicializamos los programas académicos de la sede
		sede1.ProgramasAcademicos = new List<ProgramaAcademico>();

		//Inicializamos las sedes de la institucion educativa
		ie1.Sedes = new List<Sede>();

		//Asociamos la sede a la institucion educativa
		ie1.agregarSede(sede1);
		
		//Creamos un curso de la sede
		Curso curso1 = new Curso("LENGUAJE DE PROGRAMACION 2", "INF282", 'P', 1500.00, 4, 5, new DateTime(2025,03,20), 
			new DateTime(2025,07,08), DiaSemana.MARTES, new TimeSpan(8,00,00), new TimeSpan(11,00,00));

		// Curso curso2 = new Curso("LENGUAJE DE PROGRAMACION 3", "INF283", 'V', 1500.00, 4, 3.5, new DateTime(2025,03,20), 
		// 	new DateTime(2025,07,08), DiaSemana.JUEVES, new TimeSpan(8,00,00), new TimeSpan(11,00,00));
		
		//Creamos dos talleres de la sede
		Taller taller1 = new Taller("PYTHON PARA INVESTIGACION CUANTITATIVA","TAL725",'V', 500.00, 
			new DateTime(2025,03,28),new TimeSpan(13,00,00), new TimeSpan(16,00,00));
		Taller taller2 = new Taller("INTRODUCCION A LATEX","TAL331",'V', 600.00, new DateTime(2025,03,30),
			new TimeSpan(18,00,00), new TimeSpan(22,00,00));
		
		//Asociamos el curso y los talleres a la sede
		sede1.agregarProgramaAcademico(curso1);
		//sede1.agregarProgramaAcademico(curso2);
		sede1.agregarProgramaAcademico(taller1);
		sede1.agregarProgramaAcademico(taller2);
		
		//Consultamos los programas disponibles en la primera sede de la institucion educativa
		String reporte = ie1.consultarProgramasDeSede(0);
		
		//Imprimimos el reporte
		System.Console.Write(reporte);
	}
}