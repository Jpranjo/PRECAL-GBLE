using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EquationsScript : MonoBehaviour
{

    [SerializeField] private TMP_Text equation_Parabola;
    [SerializeField] private TMP_Text equation_Circle;
    [SerializeField] private TMP_Text equation_Ellipse_top;
    [SerializeField] private TMP_Text equation_Ellipse_bottom;
    [SerializeField] private TMP_Text equation_Hyperbola_top;
    [SerializeField] private TMP_Text equation_Hyperbola_bottom;
    private float h = 0,k = 0,a = 1,b = 2;
    
    //Changes variables based off the sliders
    public void UpdateEquation_H(float value){
        h = value;
    }
    public void UpdateEquation_K(float value){
        k = value;
    }
    public void UpdateEquation_A(float value){
        a = value;
    }
    public void UpdateEquation_B(float value){
        b = value;
    }

//Variable Setters
    public void Set_H(float value){
        h = value;
    }
    public void Set_K(float value){
        k = value;
    }
    public void Set_A(float value){
        a = value;
    }
    public void Set_B(float value){
        b = value;
    }
    
    public void UpdateEquation(string type){
        string a_string,b_string,h_string,k_string;
        a_string = a.ToString();
        b_string = b.ToString();
        h_string = h.ToString();
        k_string = k.ToString();
        if(a < 0){
            a_string = "(" + a_string + ")";
        }
        if(b < 0){
            b_string = "(" + b_string + ")";
        }
        if(h < 0){
            h_string = "(" + h_string + ")";
        }
        if(k < 0){
            k_string = "(" + k_string + ")";
        }

        if(type == "Parabola"){
            equation_Parabola.text = "( y - <color=blue>" +k_string+ "</color> ) = <color=green>" +a_string+ "</color> ( x - <color=#FF4242>"+ h_string+" </color>)<sup>2</sup>";
        }
        else if(type == "Circle"){
            equation_Circle.text = "( x - <color=#FF4242>" +h_string+ "</color> )<sup>2</sup> + ( y - <color=blue>" +k_string + "</color> )<sup>2</sup> = <color=green>"+ a_string+ "<sup>2</sup>";
        }
        else if(type == "Ellipse"){
            {
                if(k < 0 && h > 0) 
                    equation_Ellipse_top.text = "         ( x - <color=#FF4242>"+ h_string+"</color>)<sup>2</sup>     ( y - <color=blue>"+k_string+"</color>)<sup>2</sup>" ; //
                else if(k < 0 && h < 0)
                    equation_Ellipse_top.text = "       ( x - <color=#FF4242>"+ h_string+"</color>)<sup>2</sup>    ( y - <color=blue>"+k_string+"</color>)<sup>2</sup>" ; //
                else if(k > 0 && h < 0)
                    equation_Ellipse_top.text = "        ( x - <color=#FF4242>"+ h_string+"</color>)<sup>2</sup>    ( y - <color=blue>"+k_string+"</color>)<sup>2</sup>" ; //
                else if(k > 0 && h > 0)
                    equation_Ellipse_top.text = "        ( x - <color=#FF4242>"+ h_string+"</color>)<sup>2</sup>        ( y - <color=blue>"+k_string+"</color>)<sup>2</sup>" ; //

                else if(k == 0 && h > 0)
                    equation_Ellipse_top.text = "        ( x - <color=#FF4242>"+ h_string+"</color>)<sup>2</sup>        ( y - <color=blue>"+k_string+"</color>)<sup>2</sup>" ; //
                else if(k == 0 && h < 0)
                    equation_Ellipse_top.text = "       ( x - <color=#FF4242>"+ h_string+"</color>)<sup>2</sup>     ( y - <color=blue>"+k_string+"</color>)<sup>2</sup>" ; //
                else if(k > 0 && h == 0)
                    equation_Ellipse_top.text = "        ( x - <color=#FF4242>"+ h_string+"</color>)<sup>2</sup>        ( y - <color=blue>"+k_string+"</color>)<sup>2</sup>" ; //
                else if(k < 0 && h == 0)
                    equation_Ellipse_top.text = "        ( x - <color=#FF4242>"+ h_string+"</color>)<sup>2</sup>      ( y - <color=blue>"+k_string+"</color>)<sup>2</sup>" ;//
                else if(k == 0 & h == 0)
                equation_Ellipse_top.text = "         ( x - <color=#FF4242>"+ h_string+"</color>)<sup>2</sup>       ( y - <color=blue>"+k_string+"</color>)<sup>2</sup>" ;//

                if(k == 10 && h == 10)
                    equation_Ellipse_top.text = "        ( x - <color=#FF4242>"+ h_string+"</color>)<sup>2</sup>     ( y - <color=blue>"+k_string+"</color>)<sup>2</sup>" ; //
                if(k == -10 && h == -10)
                    equation_Ellipse_top.text = "      ( x - <color=#FF4242>"+ h_string+"</color>)<sup>2</sup>  ( y - <color=blue>"+k_string+"</color>)<sup>2</sup>" ; //
                if(k == 10 && h == -10)
                    equation_Ellipse_top.text = "      ( x - <color=#FF4242>"+ h_string+"</color>)<sup>2</sup>    ( y - <color=blue>"+k_string+"</color>)<sup>2</sup>" ; //
                if(k == -10 && h == 10)
                    equation_Ellipse_top.text = "        ( x - <color=#FF4242>"+ h_string+"</color>)<sup>2</sup>   ( y - <color=blue>"+k_string+"</color>)<sup>2</sup>" ; //

            if(k >= 0 && h == -10)
                equation_Ellipse_top.text = "      ( x - <color=#FF4242>"+ h_string+"</color>)<sup>2</sup>     ( y - <color=blue>"+k_string+"</color>)<sup>2</sup>" ;//
            if(k < 0 && h == -10)
                equation_Ellipse_top.text = "      ( x - <color=#FF4242>"+ h_string+"</color>)<sup>2</sup>   ( y - <color=blue>"+k_string+"</color>)<sup>2</sup>" ;//
            if(k >= 0 && h == 10)
                equation_Ellipse_top.text = "       ( x - <color=#FF4242>"+ h_string+"</color>)<sup>2</sup>       ( y - <color=blue>"+k_string+"</color>)<sup>2</sup>" ;//
            if(k < 0 && h == 10)
                equation_Ellipse_top.text = "        ( x - <color=#FF4242>"+ h_string+"</color>)<sup>2</sup>    ( y - <color=blue>"+k_string+"</color>)<sup>2</sup>" ;//
            }


            if(a < 0 && b < 0)
                equation_Ellipse_bottom.text = "           <color=green>" + a_string + "</color><sup>2</sup>            <color=#DEB848>"+b_string+"</color><sup>2</sup>";
            else if(a > 0 && b > 0)
                equation_Ellipse_bottom.text = "             <color=green>" + a_string + "</color><sup>2</sup>                <color=#DEB848>"+b_string+"</color><sup>2</sup>";
            else if(a > -1 && b > -11)
                equation_Ellipse_bottom.text = "             <color=green>" + a_string + "</color><sup>2</sup>              <color=#DEB848>"+b_string+"</color><sup>2</sup>";
            else
                equation_Ellipse_bottom.text = "           <color=green>" + a_string + "</color><sup>2</sup>              <color=#DEB848>"+b_string+"</color><sup>2</sup>";
            if(a == -10 && b > -11)
                equation_Ellipse_bottom.text = "          <color=green>" + a_string + "</color><sup>2</sup>             <color=#DEB848>"+b_string+"</color><sup>2</sup>";
            if(a == 10 && b > -11)
                equation_Ellipse_bottom.text = "            <color=green>" + a_string + "</color><sup>2</sup>             <color=#DEB848>"+b_string+"</color><sup>2</sup>";
            if(a == -10 && b == 10)
                equation_Ellipse_bottom.text = "           <color=green>" + a_string + "</color><sup>2</sup>           <color=#DEB848>"+b_string+"</color><sup>2</sup>";
            if(a == 10 && b == -10)
                equation_Ellipse_bottom.text = "            <color=green>" + a_string + "</color><sup>2</sup>            <color=#DEB848>"+b_string+"</color><sup>2</sup>";
            if(a == -10 && b == -10)
                equation_Ellipse_bottom.text = "          <color=green>" + a_string + "</color><sup>2</sup>          <color=#DEB848>"+b_string+"</color><sup>2</sup>";
            if(a == 10 && b == 10)
                equation_Ellipse_bottom.text = "            <color=green>" + a_string + "</color><sup>2</sup>              <color=#DEB848>"+b_string+"</color><sup>2</sup>";

        }
        else if(type == "Hyperbola"){
            //Vertical Hyperbola
            {
                {
                    if(k < 0 && h > 0) 
                        equation_Hyperbola_top.text = "         ( y - <color=blue>"+ k_string+"</color>)<sup>2</sup>     ( x - <color=#FF4242>"+ h_string+"</color>)<sup>2</sup>" ; //
                    else if(k < 0 && h < 0)
                        equation_Hyperbola_top.text = "       ( y - <color=blue>"+ k_string+"</color>)<sup>2</sup>    ( x - <color=#FF4242>"+ h_string+"</color>)<sup>2</sup>" ; //
                    else if(k > 0 && h < 0)
                        equation_Hyperbola_top.text = "        ( y - <color=blue>"+ k_string+"</color>)<sup>2</sup>    ( x - <color=#FF4242>"+ h_string+"</color>)<sup>2</sup>" ; //
                    else if(k > 0 && h > 0)
                        equation_Hyperbola_top.text = "        ( y - <color=blue>"+ k_string+"</color>)<sup>2</sup>        ( x - <color=#FF4242>"+ h_string+"</color>)<sup>2</sup>"; //

                    else if(k == 0 && h > 0)
                        equation_Hyperbola_top.text = "        ( y - <color=blue>"+ k_string+"</color>)<sup>2</sup>        ( x - <color=#FF4242>"+ h_string+"</color>)<sup>2</sup>" ; //
                    else if(k == 0 && h < 0)
                        equation_Hyperbola_top.text = "       ( y - <color=blue>"+ k_string+"</color>)<sup>2</sup>     ( x - <color=#FF4242>"+ h_string+"</color>)<sup>2</sup>" ; //
                    else if(k > 0 && h == 0)
                        equation_Hyperbola_top.text = "        ( y - <color=blue>"+ k_string+"</color>)<sup>2</sup>        ( x - <color=#FF4242>"+ h_string+"</color>)<sup>2</sup>" ; //
                    else if(k < 0 && h == 0)
                        equation_Hyperbola_top.text = "        ( y - <color=blue>"+ k_string+"</color>)<sup>2</sup>      ( x - <color=#FF4242>"+ h_string+"</color>)<sup>2</sup>" ;//
                    else if(k == 0 & h == 0)
                    equation_Hyperbola_top.text = "         ( y - <color=blue>"+ k_string+"</color>)<sup>2</sup>       ( x - <color=#FF4242>"+ h_string+"</color>)<sup>2</sup>" ;//

                    if(k == 10 && h == 10)
                        equation_Hyperbola_top.text = "        ( y - <color=blue>"+ k_string+"</color>)<sup>2</sup>     ( x - <color=#FF4242>"+ h_string+"</color>)<sup>2</sup>" ; //
                    if(k == -10 && h == -10)
                        equation_Hyperbola_top.text = "      ( y - <color=blue>"+ k_string+"</color>)<sup>2</sup>  ( x - <color=#FF4242>"+ h_string+"</color>)<sup>2</sup>" ; //
                    if(k == 10 && h == -10)
                        equation_Hyperbola_top.text = "      ( y - <color=blue>"+ k_string+"</color>)<sup>2</sup>    ( x - <color=#FF4242>"+ h_string+"</color>)<sup>2</sup>" ; //
                    if(k == -10 && h == 10)
                        equation_Hyperbola_top.text = "        ( y - <color=blue>"+ k_string+"</color>)<sup>2</sup>   ( x - <color=#FF4242>"+ h_string+"</color>)<sup>2</sup>"; //

                if(k >= 0 && h == -10)
                    equation_Hyperbola_top.text = "      ( y - <color=blue>"+ k_string+"</color>)<sup>2</sup>     ( x - <color=#FF4242>"+ h_string+"</color>)<sup>2</sup>" ;//
                if(k < 0 && h == -10)
                    equation_Hyperbola_top.text = "      ( y - <color=blue>"+ k_string+"</color>)<sup>2</sup>   ( x - <color=#FF4242>"+ h_string+"</color>)<sup>2</sup>" ;//
                if(k >= 0 && h == 10)
                    equation_Hyperbola_top.text = "       ( y - <color=blue>"+ k_string+"</color>)<sup>2</sup>       ( x - <color=#FF4242>"+ h_string+"</color>)<sup>2</sup>" ;//
                if(k < 0 && h == 10)
                    equation_Hyperbola_top.text = "        ( y - <color=blue>"+ k_string+"</color>)<sup>2</sup>    ( x - <color=#FF4242>"+ h_string+"</color>)<sup>2</sup>" ;//
                }


                if(a < 0 && b < 0)
                    equation_Hyperbola_bottom.text = "           <color=#DEB848>" + b_string + "</color><sup>2</sup>            <color=green>"+a_string+"</color><sup>2</sup>";
                else if(a > 0 && b > 0)
                    equation_Hyperbola_bottom.text = "             <color=#DEB848>" + b_string + "</color><sup>2</sup>                <color=green>"+a_string+"</color><sup>2</sup>";
                else if(a > -1 && b > -11)
                    equation_Hyperbola_bottom.text = "             <color=#DEB848>" + b_string + "</color><sup>2</sup>              <color=green>"+a_string+"</color><sup>2</sup>";
                else
                    equation_Hyperbola_bottom.text = "           <color=#DEB848>" + b_string + "</color><sup>2</sup>              <color=green>"+a_string+"</color><sup>2</sup>";
                if(a == -10 && b > -11)
                    equation_Hyperbola_bottom.text = "          <color=#DEB848>" + b_string + "</color><sup>2</sup>             <color=green>"+a_string+"</color><sup>2</sup>";
                if(a == 10 && b > -11)
                    equation_Hyperbola_bottom.text = "            <color=#DEB848>" + b_string + "</color><sup>2</sup>             <color=green>"+a_string+"</color><sup>2</sup>";
                if(a == -10 && b == 10)
                    equation_Hyperbola_bottom.text = "           <color=#DEB848>" + b_string + "</color><sup>2</sup>           <color=green>"+a_string+"</color><sup>2</sup>";
                if(a == 10 && b == -10)
                    equation_Hyperbola_bottom.text = "            <color=#DEB848>" + b_string + "</color><sup>2</sup>            <color=green>"+a_string+"</color><sup>2</sup>";
                if(a == -10 && b == -10)
                    equation_Hyperbola_bottom.text = "          <color=#DEB848>" + b_string + "</color><sup>2</sup>          <color=green>"+a_string+"</color><sup>2</sup>";
                if(a == 10 && b == 10)
                    equation_Hyperbola_bottom.text = "            <color=#DEB848>" + b_string + "</color><sup>2</sup>              <color=green>"+a_string+"</color><sup>2</sup>";
            }
        }
    }

    private void Display_Equation_Parabola_Vertex_Form(){
        equation_Parabola.text = "( y - <color=blue>(-10)</color> ) = <color=green>-10</color> ( x- <color=#FF4242>(-10)</color> )<sup>2</sup>";
    }   
    private void Awake() {
        
    }
}
