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
  Gauss hyperbolic polynomial
  </summary> *)
[<AutoSerializable(true)>]
module GaussHyperbolicPolynomialFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GaussHyperbolicPolynomial_alpha", Description="Create a GaussHyperbolicPolynomial",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussHyperbolicPolynomial_alpha
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussHyperbolicPolynomial",Description = "Reference to GaussHyperbolicPolynomial")>] 
         gausshyperbolicpolynomial : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussHyperbolicPolynomial = Helper.toCell<GaussHyperbolicPolynomial> gausshyperbolicpolynomial "GaussHyperbolicPolynomial"  
                let _i = Helper.toCell<int> i "i" 
                let builder () = withMnemonic mnemonic ((_GaussHyperbolicPolynomial.cell :?> GaussHyperbolicPolynomialModel).Alpha
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussHyperbolicPolynomial.source + ".Alpha") 
                                               [| _GaussHyperbolicPolynomial.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussHyperbolicPolynomial.cell
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
    [<ExcelFunction(Name="_GaussHyperbolicPolynomial_beta", Description="Create a GaussHyperbolicPolynomial",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussHyperbolicPolynomial_beta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussHyperbolicPolynomial",Description = "Reference to GaussHyperbolicPolynomial")>] 
         gausshyperbolicpolynomial : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussHyperbolicPolynomial = Helper.toCell<GaussHyperbolicPolynomial> gausshyperbolicpolynomial "GaussHyperbolicPolynomial"  
                let _i = Helper.toCell<int> i "i" 
                let builder () = withMnemonic mnemonic ((_GaussHyperbolicPolynomial.cell :?> GaussHyperbolicPolynomialModel).Beta
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussHyperbolicPolynomial.source + ".Beta") 
                                               [| _GaussHyperbolicPolynomial.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussHyperbolicPolynomial.cell
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
    [<ExcelFunction(Name="_GaussHyperbolicPolynomial_mu_0", Description="Create a GaussHyperbolicPolynomial",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussHyperbolicPolynomial_mu_0
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussHyperbolicPolynomial",Description = "Reference to GaussHyperbolicPolynomial")>] 
         gausshyperbolicpolynomial : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussHyperbolicPolynomial = Helper.toCell<GaussHyperbolicPolynomial> gausshyperbolicpolynomial "GaussHyperbolicPolynomial"  
                let builder () = withMnemonic mnemonic ((_GaussHyperbolicPolynomial.cell :?> GaussHyperbolicPolynomialModel).Mu_0
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussHyperbolicPolynomial.source + ".Mu_0") 
                                               [| _GaussHyperbolicPolynomial.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussHyperbolicPolynomial.cell
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
    [<ExcelFunction(Name="_GaussHyperbolicPolynomial_w", Description="Create a GaussHyperbolicPolynomial",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussHyperbolicPolynomial_w
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussHyperbolicPolynomial",Description = "Reference to GaussHyperbolicPolynomial")>] 
         gausshyperbolicpolynomial : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussHyperbolicPolynomial = Helper.toCell<GaussHyperbolicPolynomial> gausshyperbolicpolynomial "GaussHyperbolicPolynomial"  
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((_GaussHyperbolicPolynomial.cell :?> GaussHyperbolicPolynomialModel).W
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussHyperbolicPolynomial.source + ".W") 
                                               [| _GaussHyperbolicPolynomial.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussHyperbolicPolynomial.cell
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
    [<ExcelFunction(Name="_GaussHyperbolicPolynomial_value", Description="Create a GaussHyperbolicPolynomial",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussHyperbolicPolynomial_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussHyperbolicPolynomial",Description = "Reference to GaussHyperbolicPolynomial")>] 
         gausshyperbolicpolynomial : obj)
        ([<ExcelArgument(Name="n",Description = "Reference to n")>] 
         n : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussHyperbolicPolynomial = Helper.toCell<GaussHyperbolicPolynomial> gausshyperbolicpolynomial "GaussHyperbolicPolynomial"  
                let _n = Helper.toCell<int> n "n" 
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((_GaussHyperbolicPolynomial.cell :?> GaussHyperbolicPolynomialModel).Value
                                                            _n.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussHyperbolicPolynomial.source + ".Value") 
                                               [| _GaussHyperbolicPolynomial.source
                                               ;  _n.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussHyperbolicPolynomial.cell
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
    [<ExcelFunction(Name="_GaussHyperbolicPolynomial_weightedValue", Description="Create a GaussHyperbolicPolynomial",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussHyperbolicPolynomial_weightedValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GaussHyperbolicPolynomial",Description = "Reference to GaussHyperbolicPolynomial")>] 
         gausshyperbolicpolynomial : obj)
        ([<ExcelArgument(Name="n",Description = "Reference to n")>] 
         n : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GaussHyperbolicPolynomial = Helper.toCell<GaussHyperbolicPolynomial> gausshyperbolicpolynomial "GaussHyperbolicPolynomial"  
                let _n = Helper.toCell<int> n "n" 
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((_GaussHyperbolicPolynomial.cell :?> GaussHyperbolicPolynomialModel).WeightedValue
                                                            _n.cell 
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_GaussHyperbolicPolynomial.source + ".WeightedValue") 
                                               [| _GaussHyperbolicPolynomial.source
                                               ;  _n.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GaussHyperbolicPolynomial.cell
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
    [<ExcelFunction(Name="_GaussHyperbolicPolynomial_Range", Description="Create a range of GaussHyperbolicPolynomial",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let GaussHyperbolicPolynomial_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the GaussHyperbolicPolynomial")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GaussHyperbolicPolynomial> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<GaussHyperbolicPolynomial>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<GaussHyperbolicPolynomial>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<GaussHyperbolicPolynomial>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"