using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PROYECTO_LENGUAJES.AFD;
namespace PROYECTO_LENGUAJES.Elementos_de_Lengua
{
    class TOKEN_sorter
    {
        private AFD_enteros afdEnteros = new AFD_enteros();
        private AFD_realNumber afdDecimales = new AFD_realNumber();
        private WORD_recerved wORD_Recerved = new WORD_recerved();
        private VAR_Type vAR_Type = new VAR_Type();
        private AFD_id_reference aFD_Id_Reference = new AFD_id_reference();
        private BooleanRefrence booleanRefrence = new BooleanRefrence();
        private Aritemetics_Signs aritemetics_Signs = new Aritemetics_Signs();
        private RelationalOperators relationalOperators = new RelationalOperators();
        private List<ID_token> TOKEN_type = new List<ID_token>();

        public TOKEN_sorter()
        {

        }
        public void clsificarTokens(List<LOCATION_token> DETECTED_tokens)
        {
            foreach (LOCATION_token token in DETECTED_tokens)
            {
                if (wORD_Recerved.verificacion(token.getCadena()))
                {
                    TOKEN_type.Add(new ID_token("ReservatedWord_TOKEN", token.getCadena(), token.getLineaUbicacion()));
                }
                else
                {
                    if (vAR_Type.verificacion(token.getCadena())) {
                        TOKEN_type.Add(new ID_token("VariableType_TOKEN", token.getCadena(), token.getLineaUbicacion()));
                    }
                    else
                    {
                        if (booleanRefrence.analizar(token.getCadena()))
                        {
                            TOKEN_type.Add(new ID_token("BooleanState_TOKEN", token.getCadena(), token.getLineaUbicacion()));
                        }
                        else
                        {
                            if (aFD_Id_Reference.analizar(token.getCadena()))
                            {
                                TOKEN_type.Add(new ID_token("Id_TOKEN", token.getCadena(), token.getLineaUbicacion()));
                            }
                            if (afdEnteros.analizar(token.getCadena()))
                            {
                                TOKEN_type.Add(new ID_token("Number_TOKEN", token.getCadena(), token.getLineaUbicacion()));
                            }
                            if (afdDecimales.analizar(token.getCadena()))
                            {
                                TOKEN_type.Add(new ID_token("RealNumber_TOKEN", token.getCadena(), token.getLineaUbicacion()));
                            }
                            if (aritemetics_Signs.analizar(token.getCadena()))
                            {
                                TOKEN_type.Add(new ID_token("ArithmeticSign_TOKEN", token.getCadena(), token.getLineaUbicacion()));
                            }
                            if (relationalOperators.analizar(token.getCadena()))
                            {
                                TOKEN_type.Add(new ID_token("RelationalOperator_TOKEN", token.getCadena(), token.getLineaUbicacion()));
                            }
                        }
                    }
                }
            }
        }
    }
}
