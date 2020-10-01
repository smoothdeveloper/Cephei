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
  The given date will be the implied reference date. This term structure will remain linked to the original structure, i.e., any changes in the latter will be reflected in this structure as well.  It doesn't make financial sense to have an asset-dependant implied Vol Term Structure.  This class should be used with term structures that are time dependant only.
  </summary> *)
[<AutoSerializable(true)>]
module ImpliedVolTermStructureFunction =

    (*
        Visitability
    *)
    [<ExcelFunction(Name="_ImpliedVolTermStructure_accept", Description="Create a ImpliedVolTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ImpliedVolTermStructure_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ImpliedVolTermStructure",Description = "Reference to ImpliedVolTermStructure")>] 
         impliedvoltermstructure : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ImpliedVolTermStructure = Helper.toCell<ImpliedVolTermStructure> impliedvoltermstructure "ImpliedVolTermStructure"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder () = withMnemonic mnemonic ((_ImpliedVolTermStructure.cell :?> ImpliedVolTermStructureModel).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : ImpliedVolTermStructure) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ImpliedVolTermStructure.source + ".Accept") 
                                               [| _ImpliedVolTermStructure.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ImpliedVolTermStructure.cell
                                ;  _v.cell
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
        TermStructure interface
    *)
    [<ExcelFunction(Name="_ImpliedVolTermStructure_dayCounter", Description="Create a ImpliedVolTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ImpliedVolTermStructure_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ImpliedVolTermStructure",Description = "Reference to ImpliedVolTermStructure")>] 
         impliedvoltermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ImpliedVolTermStructure = Helper.toCell<ImpliedVolTermStructure> impliedvoltermstructure "ImpliedVolTermStructure"  
                let builder () = withMnemonic mnemonic ((_ImpliedVolTermStructure.cell :?> ImpliedVolTermStructureModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_ImpliedVolTermStructure.source + ".DayCounter") 
                                               [| _ImpliedVolTermStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ImpliedVolTermStructure.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ImpliedVolTermStructure> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ImpliedVolTermStructure", Description="Create a ImpliedVolTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ImpliedVolTermStructure_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="originalTS",Description = "Reference to originalTS")>] 
         originalTS : obj)
        ([<ExcelArgument(Name="referenceDate",Description = "Reference to referenceDate")>] 
         referenceDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _originalTS = Helper.toHandle<BlackVolTermStructure> originalTS "originalTS" 
                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" 
                let builder () = withMnemonic mnemonic (Fun.ImpliedVolTermStructure 
                                                            _originalTS.cell 
                                                            _referenceDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ImpliedVolTermStructure>) l

                let source = Helper.sourceFold "Fun.ImpliedVolTermStructure" 
                                               [| _originalTS.source
                                               ;  _referenceDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _originalTS.cell
                                ;  _referenceDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ImpliedVolTermStructure> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ImpliedVolTermStructure_maxDate", Description="Create a ImpliedVolTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ImpliedVolTermStructure_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ImpliedVolTermStructure",Description = "Reference to ImpliedVolTermStructure")>] 
         impliedvoltermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ImpliedVolTermStructure = Helper.toCell<ImpliedVolTermStructure> impliedvoltermstructure "ImpliedVolTermStructure"  
                let builder () = withMnemonic mnemonic ((_ImpliedVolTermStructure.cell :?> ImpliedVolTermStructureModel).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ImpliedVolTermStructure.source + ".MaxDate") 
                                               [| _ImpliedVolTermStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ImpliedVolTermStructure.cell
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
    [<ExcelFunction(Name="_ImpliedVolTermStructure_maxStrike", Description="Create a ImpliedVolTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ImpliedVolTermStructure_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ImpliedVolTermStructure",Description = "Reference to ImpliedVolTermStructure")>] 
         impliedvoltermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ImpliedVolTermStructure = Helper.toCell<ImpliedVolTermStructure> impliedvoltermstructure "ImpliedVolTermStructure"  
                let builder () = withMnemonic mnemonic ((_ImpliedVolTermStructure.cell :?> ImpliedVolTermStructureModel).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ImpliedVolTermStructure.source + ".MaxStrike") 
                                               [| _ImpliedVolTermStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ImpliedVolTermStructure.cell
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
        VolatilityTermStructure interface
    *)
    [<ExcelFunction(Name="_ImpliedVolTermStructure_minStrike", Description="Create a ImpliedVolTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ImpliedVolTermStructure_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ImpliedVolTermStructure",Description = "Reference to ImpliedVolTermStructure")>] 
         impliedvoltermstructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ImpliedVolTermStructure = Helper.toCell<ImpliedVolTermStructure> impliedvoltermstructure "ImpliedVolTermStructure"  
                let builder () = withMnemonic mnemonic ((_ImpliedVolTermStructure.cell :?> ImpliedVolTermStructureModel).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ImpliedVolTermStructure.source + ".MinStrike") 
                                               [| _ImpliedVolTermStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ImpliedVolTermStructure.cell
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
    [<ExcelFunction(Name="_ImpliedVolTermStructure_Range", Description="Create a range of ImpliedVolTermStructure",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ImpliedVolTermStructure_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ImpliedVolTermStructure")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ImpliedVolTermStructure> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ImpliedVolTermStructure>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ImpliedVolTermStructure>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ImpliedVolTermStructure>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
