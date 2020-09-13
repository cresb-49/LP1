using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        private LogicOperators logicOperators = new LogicOperators();
        private GroupingSing groupingSing = new GroupingSing();
        private AFD_cadena afd_Cadena = new AFD_cadena();
        private AFD_Comentario afd_Comentario = new AFD_Comentario();
        private AFD_character afd_Character = new AFD_character();
        
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
                    TOKEN_type.Add(new ID_token("ReservatedWord_TOKEN", token.getCadena(), token.getLineaUbicacion(),token.getInicioCadena(),Color.Green));
                }
                else
                {
                    if (vAR_Type.verificacion(token.getCadena())) {
                        TOKEN_type.Add(new ID_token("VariableType_TOKEN", token.getCadena(), token.getLineaUbicacion(),token.getInicioCadena(),Color.Blue));
                    }
                    else
                    {
                        if (booleanRefrence.analizar(token.getCadena()))
                        {
                            TOKEN_type.Add(new ID_token("BooleanState_TOKEN", token.getCadena(), token.getLineaUbicacion(),token.getInicioCadena(),Color.Orange));
                        }
                        else
                        {
                            if (aFD_Id_Reference.analizar(token.getCadena()))
                            {
                                TOKEN_type.Add(new ID_token("Id_TOKEN", token.getCadena(), token.getLineaUbicacion(),token.getInicioCadena(),Color.Yellow));
                            }else
                            if (afd_Character.analizar(token.getCadena()))
                            {
                                TOKEN_type.Add(new ID_token("character_TOKEN", token.getCadena(), token.getLineaUbicacion(),token.getInicioCadena(),Color.Brown));
                            }
                            else
                            if (afdEnteros.analizar(token.getCadena()))
                            {
                                TOKEN_type.Add(new ID_token("Number_TOKEN", token.getCadena(), token.getLineaUbicacion(),token.getInicioCadena(),Color.BlueViolet));
                            } else
                            if (afdDecimales.analizar(token.getCadena()))
                            {
                                TOKEN_type.Add(new ID_token("RealNumber_TOKEN", token.getCadena(), token.getLineaUbicacion(),token.getInicioCadena(),Color.Cyan));
                            } else
                            if (aritemetics_Signs.analizar(token.getCadena()))
                            {
                                TOKEN_type.Add(new ID_token("ArithmeticSign_TOKEN", token.getCadena(), token.getLineaUbicacion(),token.getInicioCadena(),Color.Blue));
                            } else
                            if (relationalOperators.analizar(token.getCadena()))
                            {
                                TOKEN_type.Add(new ID_token("RelationalOperator_TOKEN", token.getCadena(), token.getLineaUbicacion(),token.getInicioCadena(),Color.Blue));
                            } else
                            if (logicOperators.analizar(token.getCadena()))
                            {
                                TOKEN_type.Add(new ID_token("LogicOperators_TOKEN", token.getCadena(), token.getLineaUbicacion(),token.getInicioCadena(), Color.Blue));
                            } else
                            if (groupingSing.analizar(token.getCadena()))
                            {
                                TOKEN_type.Add(new ID_token("GroupingSing_TOKEN", token.getCadena(), token.getLineaUbicacion(),token.getInicioCadena(), Color.Blue));
                            } else
                            if (token.getCadena().Equals("="))
                            {
                                TOKEN_type.Add(new ID_token("Asigment_TOKEN", token.getCadena(), token.getLineaUbicacion(), token.getInicioCadena(), Color.HotPink));
                            } else
                            if (token.getCadena().Equals(";"))
                            {
                                TOKEN_type.Add(new ID_token("Ending_TOKEN", token.getCadena(), token.getLineaUbicacion(), token.getInicioCadena(), Color.HotPink));
                            } else
                            if (afd_Cadena.analizar(token.getCadena()))
                            {
                                TOKEN_type.Add(new ID_token("String_TOKEN", token.getCadena(), token.getLineaUbicacion(), token.getInicioCadena(), Color.Gray));
                            } else
                            if (afd_Comentario.analizar(token.getCadena()))
                            {
                                TOKEN_type.Add(new ID_token("comment_TOKEN", token.getCadena(), token.getLineaUbicacion(), token.getInicioCadena(), Color.Red));
                            }
                            else
                            {
                                TOKEN_type.Add(new ID_token("unknown_TOKEN", token.getCadena(), token.getLineaUbicacion(), token.getInicioCadena(), Color.CornflowerBlue));
                            }
                        }
                    }
                }
            }
        }
        public List<ID_token> GetID_Tokens()
        {
            return TOKEN_type;
        }
    }
}
