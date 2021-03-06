﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
namespace WebApplicationPath
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class equipo1Entities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new equipo1Entities object using the connection string found in the 'equipo1Entities' section of the application configuration file.
        /// </summary>
        public equipo1Entities() : base("name=equipo1Entities", "equipo1Entities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new equipo1Entities object.
        /// </summary>
        public equipo1Entities(string connectionString) : base(connectionString, "equipo1Entities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new equipo1Entities object.
        /// </summary>
        public equipo1Entities(EntityConnection connection) : base(connection, "equipo1Entities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<horarios> horarios
        {
            get
            {
                if ((_horarios == null))
                {
                    _horarios = base.CreateObjectSet<horarios>("horarios");
                }
                return _horarios;
            }
        }
        private ObjectSet<horarios> _horarios;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<rutas> rutas
        {
            get
            {
                if ((_rutas == null))
                {
                    _rutas = base.CreateObjectSet<rutas>("rutas");
                }
                return _rutas;
            }
        }
        private ObjectSet<rutas> _rutas;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the horarios EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddTohorarios(horarios horarios)
        {
            base.AddObject("horarios", horarios);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the rutas EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddTorutas(rutas rutas)
        {
            base.AddObject("rutas", rutas);
        }

        #endregion

    }

    #endregion

    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="equipo1Model", Name="horarios")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class horarios : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new horarios object.
        /// </summary>
        /// <param name="idHorarios">Initial value of the idHorarios property.</param>
        /// <param name="dia">Initial value of the dia property.</param>
        /// <param name="hInicio">Initial value of the hInicio property.</param>
        /// <param name="hFin">Initial value of the hFin property.</param>
        public static horarios Createhorarios(global::System.Int32 idHorarios, global::System.String dia, global::System.Int32 hInicio, global::System.Int32 hFin)
        {
            horarios horarios = new horarios();
            horarios.idHorarios = idHorarios;
            horarios.dia = dia;
            horarios.hInicio = hInicio;
            horarios.hFin = hFin;
            return horarios;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 idHorarios
        {
            get
            {
                return _idHorarios;
            }
            set
            {
                if (_idHorarios != value)
                {
                    OnidHorariosChanging(value);
                    ReportPropertyChanging("idHorarios");
                    _idHorarios = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("idHorarios");
                    OnidHorariosChanged();
                }
            }
        }
        private global::System.Int32 _idHorarios;
        partial void OnidHorariosChanging(global::System.Int32 value);
        partial void OnidHorariosChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String dia
        {
            get
            {
                return _dia;
            }
            set
            {
                OndiaChanging(value);
                ReportPropertyChanging("dia");
                _dia = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("dia");
                OndiaChanged();
            }
        }
        private global::System.String _dia;
        partial void OndiaChanging(global::System.String value);
        partial void OndiaChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 hInicio
        {
            get
            {
                return _hInicio;
            }
            set
            {
                OnhInicioChanging(value);
                ReportPropertyChanging("hInicio");
                _hInicio = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("hInicio");
                OnhInicioChanged();
            }
        }
        private global::System.Int32 _hInicio;
        partial void OnhInicioChanging(global::System.Int32 value);
        partial void OnhInicioChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 hFin
        {
            get
            {
                return _hFin;
            }
            set
            {
                OnhFinChanging(value);
                ReportPropertyChanging("hFin");
                _hFin = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("hFin");
                OnhFinChanged();
            }
        }
        private global::System.Int32 _hFin;
        partial void OnhFinChanging(global::System.Int32 value);
        partial void OnhFinChanged();

        #endregion

    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="equipo1Model", Name="rutas")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class rutas : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new rutas object.
        /// </summary>
        /// <param name="idRutas">Initial value of the idRutas property.</param>
        /// <param name="numRuta">Initial value of the numRuta property.</param>
        /// <param name="linea">Initial value of the linea property.</param>
        /// <param name="nombre">Initial value of the nombre property.</param>
        /// <param name="latitud">Initial value of the latitud property.</param>
        /// <param name="longitud">Initial value of the longitud property.</param>
        /// <param name="afluencia">Initial value of the afluencia property.</param>
        public static rutas Createrutas(global::System.Int32 idRutas, global::System.Int32 numRuta, global::System.Int32 linea, global::System.String nombre, global::System.String latitud, global::System.String longitud, global::System.String afluencia)
        {
            rutas rutas = new rutas();
            rutas.idRutas = idRutas;
            rutas.numRuta = numRuta;
            rutas.linea = linea;
            rutas.nombre = nombre;
            rutas.latitud = latitud;
            rutas.longitud = longitud;
            rutas.afluencia = afluencia;
            return rutas;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 idRutas
        {
            get
            {
                return _idRutas;
            }
            set
            {
                if (_idRutas != value)
                {
                    OnidRutasChanging(value);
                    ReportPropertyChanging("idRutas");
                    _idRutas = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("idRutas");
                    OnidRutasChanged();
                }
            }
        }
        private global::System.Int32 _idRutas;
        partial void OnidRutasChanging(global::System.Int32 value);
        partial void OnidRutasChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 numRuta
        {
            get
            {
                return _numRuta;
            }
            set
            {
                OnnumRutaChanging(value);
                ReportPropertyChanging("numRuta");
                _numRuta = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("numRuta");
                OnnumRutaChanged();
            }
        }
        private global::System.Int32 _numRuta;
        partial void OnnumRutaChanging(global::System.Int32 value);
        partial void OnnumRutaChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 linea
        {
            get
            {
                return _linea;
            }
            set
            {
                OnlineaChanging(value);
                ReportPropertyChanging("linea");
                _linea = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("linea");
                OnlineaChanged();
            }
        }
        private global::System.Int32 _linea;
        partial void OnlineaChanging(global::System.Int32 value);
        partial void OnlineaChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                OnnombreChanging(value);
                ReportPropertyChanging("nombre");
                _nombre = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("nombre");
                OnnombreChanged();
            }
        }
        private global::System.String _nombre;
        partial void OnnombreChanging(global::System.String value);
        partial void OnnombreChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String latitud
        {
            get
            {
                return _latitud;
            }
            set
            {
                OnlatitudChanging(value);
                ReportPropertyChanging("latitud");
                _latitud = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("latitud");
                OnlatitudChanged();
            }
        }
        private global::System.String _latitud;
        partial void OnlatitudChanging(global::System.String value);
        partial void OnlatitudChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String longitud
        {
            get
            {
                return _longitud;
            }
            set
            {
                OnlongitudChanging(value);
                ReportPropertyChanging("longitud");
                _longitud = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("longitud");
                OnlongitudChanged();
            }
        }
        private global::System.String _longitud;
        partial void OnlongitudChanging(global::System.String value);
        partial void OnlongitudChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String afluencia
        {
            get
            {
                return _afluencia;
            }
            set
            {
                OnafluenciaChanging(value);
                ReportPropertyChanging("afluencia");
                _afluencia = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("afluencia");
                OnafluenciaChanged();
            }
        }
        private global::System.String _afluencia;
        partial void OnafluenciaChanging(global::System.String value);
        partial void OnafluenciaChanged();

        #endregion

    
    }

    #endregion

    
}
