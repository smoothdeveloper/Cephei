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
  This implementation is based on MINPACK (<http://www.netlib.org/minpack>,
<http://www.netlib.org/cephes/linalg.tgz>) It has a built in fd scheme to compute the jacobian, which is used by default. If useCostFunctionsJacobian is true the corresponding method in the cost function of the problem is used instead. Note that the default implementation of the jacobian in CostFunction uses a central difference (oder 2, but requiring more function evaluations) compared to the forward difference implemented here (order 1).
  </summary> *)
[<AutoSerializable(true)>]
module LevenbergMarquardtFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_LevenbergMarquardt_fcn", Description="Create a LevenbergMarquardt",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LevenbergMarquardt_fcn
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LevenbergMarquardt",Description = "Reference to LevenbergMarquardt")>] 
         levenbergmarquardt : obj)
        ([<ExcelArgument(Name="m",Description = "Reference to m")>] 
         m : obj)
        ([<ExcelArgument(Name="n",Description = "Reference to n")>] 
         n : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="iflag",Description = "Reference to iflag")>] 
         iflag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LevenbergMarquardt = Helper.toCell<LevenbergMarquardt> levenbergmarquardt "LevenbergMarquardt"  
                let _m = Helper.toCell<int> m "m" 
                let _n = Helper.toCell<int> n "n" 
                let _x = Helper.toCell<Vector> x "x" 
                let _iflag = Helper.toCell<int> iflag "iflag" 
                let builder () = withMnemonic mnemonic ((_LevenbergMarquardt.cell :?> LevenbergMarquardtModel).Fcn
                                                            _m.cell 
                                                            _n.cell 
                                                            _x.cell 
                                                            _iflag.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_LevenbergMarquardt.source + ".Fcn") 
                                               [| _LevenbergMarquardt.source
                                               ;  _m.source
                                               ;  _n.source
                                               ;  _x.source
                                               ;  _iflag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LevenbergMarquardt.cell
                                ;  _m.cell
                                ;  _n.cell
                                ;  _x.cell
                                ;  _iflag.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LevenbergMarquardt> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LevenbergMarquardt_getInfo", Description="Create a LevenbergMarquardt",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LevenbergMarquardt_getInfo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LevenbergMarquardt",Description = "Reference to LevenbergMarquardt")>] 
         levenbergmarquardt : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LevenbergMarquardt = Helper.toCell<LevenbergMarquardt> levenbergmarquardt "LevenbergMarquardt"  
                let builder () = withMnemonic mnemonic ((_LevenbergMarquardt.cell :?> LevenbergMarquardtModel).GetInfo
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_LevenbergMarquardt.source + ".GetInfo") 
                                               [| _LevenbergMarquardt.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LevenbergMarquardt.cell
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
    [<ExcelFunction(Name="_LevenbergMarquardt_jacFcn", Description="Create a LevenbergMarquardt",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LevenbergMarquardt_jacFcn
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LevenbergMarquardt",Description = "Reference to LevenbergMarquardt")>] 
         levenbergmarquardt : obj)
        ([<ExcelArgument(Name="m",Description = "Reference to m")>] 
         m : obj)
        ([<ExcelArgument(Name="n",Description = "Reference to n")>] 
         n : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="iflag",Description = "Reference to iflag")>] 
         iflag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LevenbergMarquardt = Helper.toCell<LevenbergMarquardt> levenbergmarquardt "LevenbergMarquardt"  
                let _m = Helper.toCell<int> m "m" 
                let _n = Helper.toCell<int> n "n" 
                let _x = Helper.toCell<Vector> x "x" 
                let _iflag = Helper.toCell<int> iflag "iflag" 
                let builder () = withMnemonic mnemonic ((_LevenbergMarquardt.cell :?> LevenbergMarquardtModel).JacFcn
                                                            _m.cell 
                                                            _n.cell 
                                                            _x.cell 
                                                            _iflag.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_LevenbergMarquardt.source + ".JacFcn") 
                                               [| _LevenbergMarquardt.source
                                               ;  _m.source
                                               ;  _n.source
                                               ;  _x.source
                                               ;  _iflag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LevenbergMarquardt.cell
                                ;  _m.cell
                                ;  _n.cell
                                ;  _x.cell
                                ;  _iflag.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LevenbergMarquardt> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LevenbergMarquardt", Description="Create a LevenbergMarquardt",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LevenbergMarquardt_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.LevenbergMarquardt ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LevenbergMarquardt>) l

                let source = Helper.sourceFold "Fun.LevenbergMarquardt" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LevenbergMarquardt> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LevenbergMarquardt1", Description="Create a LevenbergMarquardt",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LevenbergMarquardt_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="epsfcn",Description = "Reference to epsfcn")>] 
         epsfcn : obj)
        ([<ExcelArgument(Name="xtol",Description = "Reference to xtol")>] 
         xtol : obj)
        ([<ExcelArgument(Name="gtol",Description = "Reference to gtol")>] 
         gtol : obj)
        ([<ExcelArgument(Name="useCostFunctionsJacobian",Description = "Reference to useCostFunctionsJacobian")>] 
         useCostFunctionsJacobian : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _epsfcn = Helper.toCell<double> epsfcn "epsfcn" 
                let _xtol = Helper.toCell<double> xtol "xtol" 
                let _gtol = Helper.toCell<double> gtol "gtol" 
                let _useCostFunctionsJacobian = Helper.toDefault<bool> useCostFunctionsJacobian "useCostFunctionsJacobian" false
                let builder () = withMnemonic mnemonic (Fun.LevenbergMarquardt1 
                                                            _epsfcn.cell 
                                                            _xtol.cell 
                                                            _gtol.cell 
                                                            _useCostFunctionsJacobian.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LevenbergMarquardt>) l

                let source = Helper.sourceFold "Fun.LevenbergMarquardt1" 
                                               [| _epsfcn.source
                                               ;  _xtol.source
                                               ;  _gtol.source
                                               ;  _useCostFunctionsJacobian.source
                                               |]
                let hash = Helper.hashFold 
                                [| _epsfcn.cell
                                ;  _xtol.cell
                                ;  _gtol.cell
                                ;  _useCostFunctionsJacobian.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LevenbergMarquardt> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LevenbergMarquardt_minimize", Description="Create a LevenbergMarquardt",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LevenbergMarquardt_minimize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LevenbergMarquardt",Description = "Reference to LevenbergMarquardt")>] 
         levenbergmarquardt : obj)
        ([<ExcelArgument(Name="P",Description = "Reference to P")>] 
         P : obj)
        ([<ExcelArgument(Name="endCriteria",Description = "Reference to endCriteria")>] 
         endCriteria : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LevenbergMarquardt = Helper.toCell<LevenbergMarquardt> levenbergmarquardt "LevenbergMarquardt"  
                let _P = Helper.toCell<Problem> P "P" 
                let _endCriteria = Helper.toCell<EndCriteria> endCriteria "endCriteria" 
                let builder () = withMnemonic mnemonic ((_LevenbergMarquardt.cell :?> LevenbergMarquardtModel).Minimize
                                                            _P.cell 
                                                            _endCriteria.cell 
                                                       ) :> ICell
                let format (o : EndCriteria.Type) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LevenbergMarquardt.source + ".Minimize") 
                                               [| _LevenbergMarquardt.source
                                               ;  _P.source
                                               ;  _endCriteria.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LevenbergMarquardt.cell
                                ;  _P.cell
                                ;  _endCriteria.cell
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
    [<ExcelFunction(Name="_LevenbergMarquardt_Range", Description="Create a range of LevenbergMarquardt",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LevenbergMarquardt_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the LevenbergMarquardt")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<LevenbergMarquardt> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<LevenbergMarquardt>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<LevenbergMarquardt>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<LevenbergMarquardt>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"