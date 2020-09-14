using System;
using System.Collections.Generic;
using System.Drawing;
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
                if (wORD_Recerved.verificacion(token.contenido))
                {
                    TOKEN_type.Add(new ID_token("ReservatedWord_TOKEN", token.contenido, token.lineaUbicacion,token.inicioCadena,Color.Green));
                }
                else
                {
                    if (vAR_Type.verificacion(token.contenido)) {
                        TOKEN_type.Add(new ID_token("VariableType_TOKEN", token.contenido, token.lineaUbicacion,token.inicioCadena,Color.Blue));
                    }
                    else
                    {
                        if (booleanRefrence.analizar(token.contenido))
                        {
                            TOKEN_type.Add(new ID_token("BooleanState_TOKEN", token.contenido, token.lineaUbicacion,token.inicioCadena,Color.Orange));
                        }
                        else
                        {
                            if (aFD_Id_Reference.analizar(token.contenido))
                            {
                                TOKEN_type.Add(new ID_token("Id_TOKEN", token.contenido, token.lineaUbicacion,token.inicioCadena,Color.Yellow));
                            }else
                            if (afd_Character.analizar(token.contenido))
                            {
                                TOKEN_type.Add(new ID_token("character_TOKEN", token.contenido, token.lineaUbicacion,token.inicioCadena,Color.Brown));
                            }
                            else
                            if (afdEnteros.analizar(token.contenido))
                            {
                                TOKEN_type.Add(new ID_token("Number_TOKEN", token.contenido, token.lineaUbicacion,token.inicioCadena,Color.BlueViolet));
                            } else
                            if (afdDecimales.analizar(token.contenido))
                            {
                                TOKEN_type.Add(new ID_token("RealNumber_TOKEN", token.contenido, token.lineaUbicacion,token.inicioCadena,Color.Cyan));
                            } else
                            if (aritemetics_Signs.analizar(token.contenido))
                            {
                                TOKEN_type.Add(new ID_token("ArithmeticSign_TOKEN", token.contenido, token.lineaUbicacion,token.inicioCadena,Color.Blue));
                            } else
                            if (relationalOperators.analizar(token.contenido))
                            {
                                TOKEN_type.Add(new ID_token("RelationalOperator_TOKEN", token.contenido, token.lineaUbicacion,token.inicioCadena,Color.Blue));
                            } else
                            if (logicOperators.analizar(token.contenido))
                            {
                                TOKEN_type.Add(new ID_token("LogicOperators_TOKEN", token.contenido, token.lineaUbicacion,token.inicioCadena, Color.Blue));
                            } else
                            if (groupingSing.analizar(token.contenido))
                            {
                                TOKEN_type.Add(new ID_token("GroupingSing_TOKEN", token.contenido, token.lineaUbicacion,token.inicioCadena, Color.Blue));
                            } else
                            if (token.contenido.Equals("="))
                            {
                                TOKEN_type.Add(new ID_token("Asigment_TOKEN", token.contenido, token.lineaUbicacion, token.inicioCadena, Color.HotPink));
                            } else
                            if (token.contenido.Equals(";"))
                            {
                                TOKEN_type.Add(new ID_token("Ending_TOKEN", token.contenido, token.lineaUbicacion, token.inicioCadena, Color.HotPink));
                            } else
                            if (afd_Cadena.analizar(token.contenido))
                            {
                                TOKEN_type.Add(new ID_token("String_TOKEN", token.contenido, token.lineaUbicacion, token.inicioCadena, Color.Gray));
                            } else
                            if (afd_Comentario.analizar(token.contenido))
                            {
                                TOKEN_type.Add(new ID_token("comment_TOKEN", token.contenido, token.lineaUbicacion, token.inicioCadena, Color.Red));
                            }
                            else
                            {
                                TOKEN_type.Add(new ID_token("unknown_TOKEN", token.contenido, token.lineaUbicacion, token.inicioCadena, Color.CornflowerBlue));
                            }
                        }
                    }
                }
            }
            DETECTED_tokens = null;
        }
        public List<ID_token> GetID_Tokens()
        {
            return TOKEN_type;
        }
    }
}
