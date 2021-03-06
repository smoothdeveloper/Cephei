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
(*!!
(* <summary>
Abstract base class which allows step conditions to use both payoff and array functions
  </summary> *)
[<AutoSerializable(true)>]
module CurveDependentStepConditionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CurveDependentStepCondition_applyTo", Description="Create a CurveDependentStepCondition",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CurveDependentStepCondition_applyTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CurveDependentStepCondition",Description = "CurveDependentStepCondition")>] 
         curvedependentstepcondition : obj)
        ([<ExcelArgument(Name="o",Description = "Object")>] 
         o : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CurveDependentStepCondition = Helper.toCell<CurveDependentStepCondition> curvedependentstepcondition "CurveDependentStepCondition"  
                let _o = Helper.toCell<Object> o "o" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((CurveDependentStepConditionModel.Cast _CurveDependentStepCondition.cell).ApplyTo
                                                            _o.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : CurveDependentStepCondition) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_CurveDependentStepCondition.source + ".ApplyTo") 

                                               [| _o.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CurveDependentStepCondition.cell
                                ;  _o.cell
                                ;  _t.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_CurveDependentStepCondition_Range", Description="Create a range of CurveDependentStepCondition",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let CurveDependentStepCondition_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CurveDependentStepCondition> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CurveDependentStepCondition>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<CurveDependentStepCondition>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<CurveDependentStepCondition>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
