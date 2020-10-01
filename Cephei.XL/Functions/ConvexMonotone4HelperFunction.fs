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

  </summary> *)
[<AutoSerializable(true)>]
module ConvexMonotone4HelperFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ConvexMonotone4Helper", Description="Create a ConvexMonotone4Helper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvexMonotone4Helper_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="xPrev",Description = "Reference to xPrev")>] 
         xPrev : obj)
        ([<ExcelArgument(Name="xNext",Description = "Reference to xNext")>] 
         xNext : obj)
        ([<ExcelArgument(Name="gPrev",Description = "Reference to gPrev")>] 
         gPrev : obj)
        ([<ExcelArgument(Name="gNext",Description = "Reference to gNext")>] 
         gNext : obj)
        ([<ExcelArgument(Name="fAverage",Description = "Reference to fAverage")>] 
         fAverage : obj)
        ([<ExcelArgument(Name="eta4",Description = "Reference to eta4")>] 
         eta4 : obj)
        ([<ExcelArgument(Name="prevPrimitive",Description = "Reference to prevPrimitive")>] 
         prevPrimitive : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _xPrev = Helper.toCell<double> xPrev "xPrev" 
                let _xNext = Helper.toCell<double> xNext "xNext" 
                let _gPrev = Helper.toCell<double> gPrev "gPrev" 
                let _gNext = Helper.toCell<double> gNext "gNext" 
                let _fAverage = Helper.toCell<double> fAverage "fAverage" 
                let _eta4 = Helper.toCell<double> eta4 "eta4" 
                let _prevPrimitive = Helper.toCell<double> prevPrimitive "prevPrimitive" 
                let builder () = withMnemonic mnemonic (Fun.ConvexMonotone4Helper 
                                                            _xPrev.cell 
                                                            _xNext.cell 
                                                            _gPrev.cell 
                                                            _gNext.cell 
                                                            _fAverage.cell 
                                                            _eta4.cell 
                                                            _prevPrimitive.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ConvexMonotone4Helper>) l

                let source = Helper.sourceFold "Fun.ConvexMonotone4Helper" 
                                               [| _xPrev.source
                                               ;  _xNext.source
                                               ;  _gPrev.source
                                               ;  _gNext.source
                                               ;  _fAverage.source
                                               ;  _eta4.source
                                               ;  _prevPrimitive.source
                                               |]
                let hash = Helper.hashFold 
                                [| _xPrev.cell
                                ;  _xNext.cell
                                ;  _gPrev.cell
                                ;  _gNext.cell
                                ;  _fAverage.cell
                                ;  _eta4.cell
                                ;  _prevPrimitive.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConvexMonotone4Helper> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ConvexMonotone4Helper_fNext", Description="Create a ConvexMonotone4Helper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvexMonotone4Helper_fNext
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvexMonotone4Helper",Description = "Reference to ConvexMonotone4Helper")>] 
         convexmonotone4helper : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvexMonotone4Helper = Helper.toCell<ConvexMonotone4Helper> convexmonotone4helper "ConvexMonotone4Helper"  
                let builder () = withMnemonic mnemonic ((_ConvexMonotone4Helper.cell :?> ConvexMonotone4HelperModel).FNext
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvexMonotone4Helper.source + ".FNext") 
                                               [| _ConvexMonotone4Helper.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvexMonotone4Helper.cell
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
    [<ExcelFunction(Name="_ConvexMonotone4Helper_primitive", Description="Create a ConvexMonotone4Helper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvexMonotone4Helper_primitive
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvexMonotone4Helper",Description = "Reference to ConvexMonotone4Helper")>] 
         convexmonotone4helper : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvexMonotone4Helper = Helper.toCell<ConvexMonotone4Helper> convexmonotone4helper "ConvexMonotone4Helper"  
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((_ConvexMonotone4Helper.cell :?> ConvexMonotone4HelperModel).Primitive
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvexMonotone4Helper.source + ".Primitive") 
                                               [| _ConvexMonotone4Helper.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvexMonotone4Helper.cell
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
    [<ExcelFunction(Name="_ConvexMonotone4Helper_value", Description="Create a ConvexMonotone4Helper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvexMonotone4Helper_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvexMonotone4Helper",Description = "Reference to ConvexMonotone4Helper")>] 
         convexmonotone4helper : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvexMonotone4Helper = Helper.toCell<ConvexMonotone4Helper> convexmonotone4helper "ConvexMonotone4Helper"  
                let _x = Helper.toCell<double> x "x" 
                let builder () = withMnemonic mnemonic ((_ConvexMonotone4Helper.cell :?> ConvexMonotone4HelperModel).Value
                                                            _x.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvexMonotone4Helper.source + ".Value") 
                                               [| _ConvexMonotone4Helper.source
                                               ;  _x.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvexMonotone4Helper.cell
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
    [<ExcelFunction(Name="_ConvexMonotone4Helper_Range", Description="Create a range of ConvexMonotone4Helper",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ConvexMonotone4Helper_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ConvexMonotone4Helper")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ConvexMonotone4Helper> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ConvexMonotone4Helper>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ConvexMonotone4Helper>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ConvexMonotone4Helper>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
