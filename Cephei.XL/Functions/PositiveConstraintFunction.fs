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
  %Constraint imposing positivity to all arguments
  </summary> *)
[<AutoSerializable(true)>]
module PositiveConstraintFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_PositiveConstraint", Description="Create a PositiveConstraint",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PositiveConstraint_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.PositiveConstraint ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<PositiveConstraint>) l

                let source = Helper.sourceFold "Fun.PositiveConstraint" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PositiveConstraint> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_PositiveConstraint_empty", Description="Create a PositiveConstraint",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PositiveConstraint_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PositiveConstraint",Description = "Reference to PositiveConstraint")>] 
         positiveconstraint : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PositiveConstraint = Helper.toCell<PositiveConstraint> positiveconstraint "PositiveConstraint"  
                let builder () = withMnemonic mnemonic ((_PositiveConstraint.cell :?> PositiveConstraintModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PositiveConstraint.source + ".Empty") 
                                               [| _PositiveConstraint.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PositiveConstraint.cell
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
        ! Returns lower bound for given parameters
    *)
    [<ExcelFunction(Name="_PositiveConstraint_lowerBound", Description="Create a PositiveConstraint",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PositiveConstraint_lowerBound
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PositiveConstraint",Description = "Reference to PositiveConstraint")>] 
         positiveconstraint : obj)
        ([<ExcelArgument(Name="parameters",Description = "Reference to parameters")>] 
         parameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PositiveConstraint = Helper.toCell<PositiveConstraint> positiveconstraint "PositiveConstraint"  
                let _parameters = Helper.toCell<Vector> parameters "parameters" 
                let builder () = withMnemonic mnemonic ((_PositiveConstraint.cell :?> PositiveConstraintModel).LowerBound
                                                            _parameters.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_PositiveConstraint.source + ".LowerBound") 
                                               [| _PositiveConstraint.source
                                               ;  _parameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PositiveConstraint.cell
                                ;  _parameters.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PositiveConstraint> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! Tests if params satisfy the constraint
    *)
    [<ExcelFunction(Name="_PositiveConstraint_test", Description="Create a PositiveConstraint",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PositiveConstraint_test
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PositiveConstraint",Description = "Reference to PositiveConstraint")>] 
         positiveconstraint : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PositiveConstraint = Helper.toCell<PositiveConstraint> positiveconstraint "PositiveConstraint"  
                let _p = Helper.toCell<Vector> p "p" 
                let builder () = withMnemonic mnemonic ((_PositiveConstraint.cell :?> PositiveConstraintModel).Test
                                                            _p.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_PositiveConstraint.source + ".Test") 
                                               [| _PositiveConstraint.source
                                               ;  _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PositiveConstraint.cell
                                ;  _p.cell
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
    [<ExcelFunction(Name="_PositiveConstraint_update", Description="Create a PositiveConstraint",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PositiveConstraint_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PositiveConstraint",Description = "Reference to PositiveConstraint")>] 
         positiveconstraint : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        ([<ExcelArgument(Name="direction",Description = "Reference to direction")>] 
         direction : obj)
        ([<ExcelArgument(Name="beta",Description = "Reference to beta")>] 
         beta : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PositiveConstraint = Helper.toCell<PositiveConstraint> positiveconstraint "PositiveConstraint"  
                let _p = Helper.toCell<Vector> p "p" 
                let _direction = Helper.toCell<Vector> direction "direction" 
                let _beta = Helper.toCell<double> beta "beta" 
                let builder () = withMnemonic mnemonic ((_PositiveConstraint.cell :?> PositiveConstraintModel).Update
                                                            _p.cell 
                                                            _direction.cell 
                                                            _beta.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_PositiveConstraint.source + ".Update") 
                                               [| _PositiveConstraint.source
                                               ;  _p.source
                                               ;  _direction.source
                                               ;  _beta.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PositiveConstraint.cell
                                ;  _p.cell
                                ;  _direction.cell
                                ;  _beta.cell
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
        ! Returns upper bound for given parameters
    *)
    [<ExcelFunction(Name="_PositiveConstraint_upperBound", Description="Create a PositiveConstraint",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PositiveConstraint_upperBound
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="PositiveConstraint",Description = "Reference to PositiveConstraint")>] 
         positiveconstraint : obj)
        ([<ExcelArgument(Name="parameters",Description = "Reference to parameters")>] 
         parameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _PositiveConstraint = Helper.toCell<PositiveConstraint> positiveconstraint "PositiveConstraint"  
                let _parameters = Helper.toCell<Vector> parameters "parameters" 
                let builder () = withMnemonic mnemonic ((_PositiveConstraint.cell :?> PositiveConstraintModel).UpperBound
                                                            _parameters.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_PositiveConstraint.source + ".UpperBound") 
                                               [| _PositiveConstraint.source
                                               ;  _parameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _PositiveConstraint.cell
                                ;  _parameters.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<PositiveConstraint> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_PositiveConstraint_Range", Description="Create a range of PositiveConstraint",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let PositiveConstraint_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the PositiveConstraint")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<PositiveConstraint> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<PositiveConstraint>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<PositiveConstraint>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<PositiveConstraint>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
