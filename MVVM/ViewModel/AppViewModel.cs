using PracticaEx.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PracticaEx.MVVM.ViewModel
{
    public class AppViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Tareas> ListaTareas { get; set; }
        public ObservableCollection<Tareas> ListaTareasCompletadas { get; set; }
        public ObservableCollection<Tareas> ListaTareasEnProgreso { get; set; }
        public ObservableCollection<Tareas> ListaTareasFinalizadas { get; set; }
        private string _nuevoNombreTarea;
        private string _nuevaDescripcionTarea;
        private int _nuevoIdTarea;
        private string _nuevoEstadoTarea;
        public AppViewModel()
        {
            ListaTareas = new ObservableCollection<Tareas>()
            {
                new Tareas()
                {
                    Descripcion = "Implementar la conexión a la base de datos local (SQLite) para persistencia de datos.",
                    ID = 1,
                    Estado = "En Progreso",
                    Nombre = "Conexión a Base de Datos"
                },

                new Tareas()
                {
                    Descripcion = "Diseñar y maquetar la interfaz principal de la aplicación utilizando Grid y StackPanel.",
                    ID = 2,
                    Estado = "Completada",
                    Nombre = "Maquetación UI Principal"
                },

                new Tareas()
                {
                    Descripcion = "Crear el 'ViewModel' para la vista de listado de elementos y aplicar el patrón MVVM.",
                    ID = 3,
                    Estado = "Pendiente",
                    Nombre = "Desarrollo del ViewModel"
                },

                new Tareas()
                {
                    Descripcion = "Configurar los comandos 'Guardar' y 'Cancelar' utilizando ICommand y 'RelayCommand'.",
                    ID = 4,
                    Estado = "Pendiente",
                    Nombre = "Implementación de Comandos"
                },

                new Tareas()
                {
                    Descripcion = "Añadir validación a los campos de entrada de texto (TextBox) en el formulario de detalles.",
                    ID = 5,
                    Estado = "En Progreso",
                    Nombre = "Validación de Formularios"
                }
            };
            FiltarTareas();
        }

        public String NuevoNombreTarea
        {
            get { return _nuevoNombreTarea; }
            set
            {
                _nuevoNombreTarea = value;
                OnPropertyChanged();
            }
        }
        public String NuevaDescripcionTarea
        {
            get { return _nuevaDescripcionTarea; }
            set
            {
                _nuevaDescripcionTarea = value;
                OnPropertyChanged();
            }
        }
        public String NuevoEstadoTarea
        {
            get { return _nuevoEstadoTarea; }
            set
            {
                _nuevoEstadoTarea = value;
                OnPropertyChanged();
            }
        }
        public int NuevoIdTarea
        {
            get { return _nuevoIdTarea; }
            set
            {
                _nuevoIdTarea = value;
                OnPropertyChanged();
            }
        }

        public void AgregarTarea(object parameter)
        {
            Tareas nuevaTarea = new Tareas
            {
                ID = NuevoIdTarea,
                Nombre = NuevoNombreTarea,
                Descripcion = NuevaDescripcionTarea,
                Estado = NuevoEstadoTarea
            };
            ListaTareas.Add(nuevaTarea);
            OnPropertyChanged();
        }

        public void FiltarTareas()
        {
            foreach (var Tarea in ListaTareas)
            {
                if (Tarea.Estado == "Completada")
                {
                    ListaTareasCompletadas.Add(Tarea);
                } else if(Tarea.Estado == "En Progreso")
                {
                    ListaTareasEnProgreso.Add(Tarea);
                }
                else if (Tarea.Estado == "Finalizada")
                {
                    ListaTareasFinalizadas.Add(Tarea);
                }
            }
            OnPropertyChanged();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string nombre = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }
    }
}
