using PROYECTO_LENGUAJES.AFD;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

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


        private string memoriaAsignacion = "";

        private ID_token temp;
        public TOKEN_sorter()
        {

        }
        public void clsificarTokens(List<LOCATION_token> DETECTED_tokens)
        {
            foreach (LOCATION_token token in DETECTED_tokens)
            {
                if (wORD_Recerved.verificacion(token.contenido))
                {
                    temp = new ID_token("ReservatedWord_TOKEN", token.contenido, token.lineaUbicacion, token.inicioCadena, Color.Green);
                    temp.lexema = temp.contenido.ToUpper();
                    if (temp.lexema.Equals("LEER"))
                    {
                        memoriaAsignacion = "CADENA";
                    }
                    TOKEN_type.Add(temp);
                }
                else
                {
                    if (vAR_Type.verificacion(token.contenido))
                    {
                        temp = new ID_token("VariableType_TOKEN", token.contenido, token.lineaUbicacion, token.inicioCadena, Color.Blue);
                        temp.lexema = temp.contenido.ToUpper();
                        memoriaAsignacion = temp.lexema;
                        TOKEN_type.Add(temp);
                    }
                    else
                    {
                        if (booleanRefrence.analizar(token.contenido))
                        {
                            temp = new ID_token("BooleanState_TOKEN", token.contenido, token.lineaUbicacion, token.inicioCadena, Color.Orange);
                            temp.lexema = temp.contenido.ToUpper();
                            TOKEN_type.Add(temp);
                            
                        }
                        else
                        {
                            if (aFD_Id_Reference.analizar(token.contenido))
                            {
                                temp = new ID_token("Id_TOKEN", token.contenido, token.lineaUbicacion, token.inicioCadena, Color.Yellow);
                                String IdTemp = this.buscarVariableDeclarada(temp);
                                if (!(IdTemp.Equals("")))
                                {
                                    temp.lexema = IdTemp;
                                    TOKEN_type.Add(temp);
                                }
                                else
                                {
                                    temp.lexema = "ID_" + memoriaAsignacion;
                                    TOKEN_type.Add(temp);
                                }
                            }
                            else
                            if (afd_Character.analizar(token.contenido))
                            {
                                temp = new ID_token("character_TOKEN", token.contenido, token.lineaUbicacion, token.inicioCadena, Color.Brown);
                                temp.lexema = "LETRA";
                                TOKEN_type.Add(temp);
                            }
                            else
                            if (afdEnteros.analizar(token.contenido))
                            {
                                temp = new ID_token("Number_TOKEN", token.contenido, token.lineaUbicacion, token.inicioCadena, Color.BlueViolet);
                                temp.lexema = "NUMERO_E";
                                TOKEN_type.Add(temp);
                            }
                            else
                            if (afdDecimales.analizar(token.contenido))
                            {
                                temp = new ID_token("RealNumber_TOKEN", token.contenido, token.lineaUbicacion, token.inicioCadena, Color.Cyan);
                                temp.lexema = "NUMERO_D";
                                TOKEN_type.Add(temp);
                            }
                            else
                            if (aritemetics_Signs.analizar(token.contenido))
                            {
                                temp = new ID_token("ArithmeticSign_TOKEN", token.contenido, token.lineaUbicacion, token.inicioCadena, Color.Blue);
                                temp.lexema = temp.contenido;
                                TOKEN_type.Add(temp);
                            }
                            else
                            if (relationalOperators.analizar(token.contenido))
                            {
                                temp = new ID_token("RelationalOperator_TOKEN", token.contenido, token.lineaUbicacion, token.inicioCadena, Color.Blue);
                                temp.lexema = "OP_RELACIONAL";
                                TOKEN_type.Add(temp);
                            }
                            else
                            if (logicOperators.analizar(token.contenido))
                            {
                                temp = new ID_token("LogicOperators_TOKEN", token.contenido, token.lineaUbicacion, token.inicioCadena, Color.Blue);
                                temp.lexema = "OP_LOGICO";
                                TOKEN_type.Add(temp);
                            }
                            else
                            if (groupingSing.analizar(token.contenido))
                            {
                                temp = new ID_token("GroupingSing_TOKEN", token.contenido, token.lineaUbicacion, token.inicioCadena, Color.Blue);
                                temp.lexema = temp.contenido;
                                TOKEN_type.Add(temp);
                            }
                            else
                            if (token.contenido.Equals("="))
                            {
                                temp = new ID_token("Asigment_TOKEN", token.contenido, token.lineaUbicacion, token.inicioCadena, Color.HotPink);
                                temp.lexema = "=";
                                memoriaAsignacion = "";
                                TOKEN_type.Add(temp);
                            }
                            else
                            if (token.contenido.Equals(";"))
                            {
                                temp = new ID_token("Ending_TOKEN", token.contenido, token.lineaUbicacion, token.inicioCadena, Color.HotPink);
                                temp.lexema = ";";
                                memoriaAsignacion = "";
                                TOKEN_type.Add(temp);
                            }
                            else
                            if (token.contenido.Equals(","))
                            {
                                temp = new ID_token("SeparadorVar_TOKEN", token.contenido, token.lineaUbicacion, token.inicioCadena, Color.OrangeRed);
                                temp.lexema = ",";
                                TOKEN_type.Add(temp);
                            }
                            else
                            if (afd_Cadena.analizar(token.contenido))
                            {
                                temp = new ID_token("String_TOKEN", token.contenido, token.lineaUbicacion, token.inicioCadena, Color.Gray);
                                temp.lexema = "CAD_TEXTO";
                                TOKEN_type.Add(temp);
                            }
                            else
                            if (afd_Comentario.analizar(token.contenido))
                            {
                                temp = new ID_token("comment_TOKEN", token.contenido, token.lineaUbicacion, token.inicioCadena, Color.Red);
                                temp.lexema = "COMENTARIO";
                                TOKEN_type.Add(temp);
                            }
                            else
                            {
                                temp = new ID_token("unknown_TOKEN", token.contenido, token.lineaUbicacion, token.inicioCadena, Color.CornflowerBlue);
                                temp.lexema = "ERROR";
                                TOKEN_type.Add(temp);
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
        
        private String buscarVariableDeclarada(ID_token token)
        {
            foreach(ID_token tok in TOKEN_type)
            {
                if (tok.contenido.Equals(token.contenido))
                {
                    return tok.lexema;
                }
            }
            return "";
        }
    }
}
