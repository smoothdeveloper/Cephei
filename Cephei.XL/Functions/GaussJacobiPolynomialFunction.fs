﻿(*
Copyright (C) 2020 Cepheis Ltd (steve.channell@cepheis.com)

This file is part of Cephei.QL Project https://github.com/channell/Cephei

Cephei.QL is open source software based on QLNet  you can redistribute it and/or modify it
under the terms of the Cephei.QL license.  You should have received a
copy of the license along with this program; if not, license is
available at <https://github.com/channell/Cephei/LICENSE>.

QLNet is a based on QuantLib, a free-software/open-source library
for financial quantitative analysts and developers - http://quantlib.org/
The QuantLib license is available online at http://quantlib.org/license.shtml.

This program is distributed in the hope that it will be useful, but WITHOUT
ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
FOR A PARTICULAR PURPOSE.  See the license for more details.
*)
namespace Cephei.XL

open ExcelDna.Integration
open Cephei.Cell
open Cephei.Cell.Generic
open Cephei.QL
open System.Collections
open System
open System.Linq
open QLNet
open Cephei.XL.Helper

(* <summary>
  Gauss-Jacobi polynomial
  </summary> *)
[<AutoSerializable(true)>]
module GaussJacobiPolynomialFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GaussJacobiPolynomial_alpha", Description="Create a GaussJacobiPolynomial",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussJacobiPolynomial_alpha
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussJacobiPolynomial",Description = "Reference to GaussJacobiPolynomial")>] 
         gaussjacobipolynomial : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussJacobiPolynomial = Helper.toCell<GaussJacobiPolynomial> gaussjacobipolynomial "GaussJacobiPolynomial"  
                let _i = Helper.toCell<int> i "i" 
                let builder () = withMnemonic mnemonic ((_GaussJacobiPolynomial.cell :?> GaussJacobiPolynomialModel).Alpha
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussJacobiPolynomial.source + ".Alpha") 
                                               [| _GaussJacobiPolynomial.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussJacobiPolynomial.cell
                                ;  _i.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GaussJacobiPolynomial_beta", Description="Create a GaussJacobiPolynomial",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussJacobiPolynomial_beta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussJacobiPolynomial",Description = "Reference to GaussJacobiPolynomial")>] 
         gaussjacobipolynomial : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussJacobiPolynomial = Helper.toCell<GaussJacobiPolynomial> gaussjacobipolynomial "GaussJacobiPolynomial"  
                let _i = Helper.toCell<int> i "i" 
                let builder () = withMnemonic mnemonic ((_GaussJacobiPolynomial.cell :?> GaussJacobiPolynomialModel).Beta
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussJacobiPolynomial.source + ".Beta") 
                                               [| _GaussJacobiPolynomial.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussJacobiPolynomial.cell
                                ;  _i.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GaussJacobiPolynomial", Description="Create a GaussJacobiPolynomial",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussJacobiPolynomial_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="alpha",Description = "Reference to alpha")>] 
         alpha : obj)
        ([<ExcelArgument(Name="beta",Description = "Reference to beta")>] 
         beta : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _alpha = Helper.toCell<double> alpha "alpha" 
                let _beta = Helper.toCell<double> beta "beta" 
                let builder () = withMnemonic mnemonic (Fun.GaussJacobiPolynomial 
                                                            _alpha.cell 
                                                            _beta.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GaussJacobiPolynomial>) l

                let source = Helper.sourceFold "Fun.GaussJacobiPolynomial" 
                                               [| _alpha.source
                                               ;  _beta.source
                                               |]
                let hash = Helper.hashFold 
                                [| _alpha.cell
                                ;  _beta.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GaussJacobiPolynomial> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GaussJacobiPolynomial_mu_0", Description="Create a GaussJacobiPolynomial",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussJacobiPolynomial_mu_0
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussJacobiPolynomial",Description = "Reference to GaussJacobiPolynomial")>] 
         gaussjacobipolynomial : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussJacobiPolynomial = Helper.toCell<GaussJacobiPolynomial> gaussjacobipolynomial "GaussJacobiPolynomial"  
                let builder () = withMnemonic mnemonic ((_GaussJacobiPolynomial.cell :?> GaussJacobiPolynomialModel).Mu_0
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussJacobiPolynomial.source + ".Mu_0") 
                                               [| _GaussJacobiPolynomial.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussJacobiPolynomial.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GaussJacobiPolynomial_w", Description="Create a GaussJacobiPolynomial",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussJacobiPolynomial_w
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussJacobiPolynomial",Description = "Reference to GaussJacobiPolynomial")>] 
         gaussjacobipolynomial : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussJacobiPolynomial = Helper.toCell<GaussJacobiPolynomial> gaussjacobipolynomial "GaussJacobiPolynomial"  
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((_GaussJacobiPolynomial.cell :?> GaussJacobiPolynomialModel).W
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussJacobiPolynomial.source + ".W") 
                                               [| _GaussJacobiPolynomial.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussJacobiPolynomial.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GaussJacobiPolynomial_value", Description="Create a GaussJacobiPolynomial",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussJacobiPolynomial_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussJacobiPolynomial",Description = "Reference to GaussJacobiPolynomial")>] 
         gaussjacobipolynomial : obj)
        ([<ExcelArgument(Name="n",Description = "Reference to n")>] 
         n : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussJacobiPolynomial = Helper.toCell<GaussJacobiPolynomial> gaussjacobipolynomial "GaussJacobiPolynomial"  
                let _n = Helper.toCell<int> n "n" 
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((_GaussJacobiPolynomial.cell :?> GaussJacobiPolynomialModel).Value
                                                            _n.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussJacobiPolynomial.source + ".Value") 
                                               [| _GaussJacobiPolynomial.source
                                               ;  _n.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussJacobiPolynomial.cell
                                ;  _n.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GaussJacobiPolynomial_weightedValue", Description="Create a GaussJacobiPolynomial",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussJacobiPolynomial_weightedValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussJacobiPolynomial",Description = "Reference to GaussJacobiPolynomial")>] 
         gaussjacobipolynomial : obj)
        ([<ExcelArgument(Name="n",Description = "Reference to n")>] 
         n : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussJacobiPolynomial = Helper.toCell<GaussJacobiPolynomial> gaussjacobipolynomial "GaussJacobiPolynomial"  
                let _n = Helper.toCell<int> n "n" 
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((_GaussJacobiPolynomial.cell :?> GaussJacobiPolynomialModel).WeightedValue
                                                            _n.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussJacobiPolynomial.source + ".WeightedValue") 
                                               [| _GaussJacobiPolynomial.source
                                               ;  _n.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussJacobiPolynomial.cell
                                ;  _n.cell
                                ;  _x.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_GaussJacobiPolynomial_Range", Description="Create a range of GaussJacobiPolynomial",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussJacobiPolynomial_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the GaussJacobiPolynomial")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GaussJacobiPolynomial> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<GaussJacobiPolynomial>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<GaussJacobiPolynomial>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<GaussJacobiPolynomial>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
