namespace TPINTEGRADOR.Models.daos.auxClasses
{
    public static class DataFactory
    {
        #region Private Methods

        /// <summary>
        ///     Gets an instance of the dao associated to the givenn type.
        /// </summary>
        /// <returns></returns>
        private static T GetDao<T>()
        {
            var type = typeof(T);

            var constructor = type.GetConstructor(Type.EmptyTypes);

            var dao = constructor != null ? constructor.Invoke(new object[] { }) : null;

            if (dao == null) throw new Exception();//MissingDaoException(type);

            return (T)dao;
        }

        #endregion

        #region Public Properties

        public static OrganismoDao OrganismoDao => GetDao<OrganismoDao>();
        public static IncidenteDao IncidenteDao => GetDao<IncidenteDao>();
        public static ParticipacionDao ParticipacionDao => GetDao<ParticipacionDao>();
        public static ServicioDao ServicioDao => GetDao<ServicioDao>();
        public static RankingDao RankingDao => GetDao<RankingDao>();
        public static PersonaDao PersonaDao => GetDao<PersonaDao>();
        public static LocalizacionDao LocalizacionDao => GetDao<LocalizacionDao>();
        public static ComunidadDao ComunidadDao => GetDao<ComunidadDao>();
        public static UsuarioDao UsuarioDao => GetDao<UsuarioDao>();
        public static NotificacionDao NotificacionDao => GetDao<NotificacionDao>();

        #endregion
    }
}