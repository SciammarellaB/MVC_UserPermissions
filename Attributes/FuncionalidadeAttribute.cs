using MVC_UserPermissions.Enumerados;
using System.Collections.Concurrent;

namespace MVC_UserPermissions.Attributes
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class FuncionalidadeAttribute : Attribute
    {
        public FuncionalidadeAttribute(string displayName)
        {
            this.DisplayName = displayName;
        }

        public string DisplayName { get; private set; }

        public bool IsGrupo { get; set; }

        private Permissoes? _parent;

        public string Descricao { get; set; }

        public Permissoes Parent
        {
            get { return _parent.Value; }
            set { _parent = value; }
        }

        public bool HasParent
        {
            get { return this._parent.HasValue; }
        }

        public FuncionalidadeAttribute ParentAttribute
        {
            get { return this._parent.HasValue ? Read(this.Parent) : null; }
        }

        private static ConcurrentDictionary<Permissoes, FuncionalidadeAttribute> cacheFunc
            = new ConcurrentDictionary<Permissoes, FuncionalidadeAttribute>();

        public static FuncionalidadeAttribute Read(Permissoes func)
        {
            return cacheFunc.GetOrAdd(func, ReadWithoutCache);
        }

        private static FuncionalidadeAttribute ReadWithoutCache(Permissoes func)
        {
            var funcAttr = typeof(Permissoes)
                .GetMember(func.ToString())[0]
                .GetCustomAttributes(typeof(FuncionalidadeAttribute), false)
                .Cast<FuncionalidadeAttribute>()
                .SingleOrDefault();

            if (funcAttr != null)
            {
                funcAttr.IsValid = true;
                funcAttr.Valor = func;
            }

            return funcAttr;
        }

        public Permissoes Valor { get; set; }

        /// <summary>
        /// Determina se este atributo foi obtido de uma fonte válida.
        /// </summary>
        public bool IsValid { get; private set; }
    }
}
