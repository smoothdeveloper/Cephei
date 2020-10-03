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
(*
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
  The swaption vol cube is made up of ordered swaption vol surface layers, each layer referring to a swap index of a given length (in years), all indexes belonging to the same family. In order to identify the family (and its market conventions) an index of whatever length from that family must be passed in as swapIndexBase.  Often for short swap length the swap index family is different, e.g. the EUR case: swap vs 6M Euribor is used for length>1Y, while swap vs 3M Euribor is used for the 1Y length. The shortSwapIndexBase is used to identify this second family.
  </summary> *)
[<AutoSerializable(true)>]
module SwaptionVolCube2Function =

    (*
        
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="atmVolStructure",Description = "Reference to atmVolStructure")>] 
         atmVolStructure : obj)
        ([<ExcelArgument(Name="optionTenors",Description = "Reference to optionTenors")>] 
         optionTenors : obj)
        ([<ExcelArgument(Name="swapTenors",Description = "Reference to swapTenors")>] 
         swapTenors : obj)
        ([<ExcelArgument(Name="strikeSpreads",Description = "Reference to strikeSpreads")>] 
         strikeSpreads : obj)
        ([<ExcelArgument(Name="volSpreads",Description = "Reference to volSpreads")>] 
         volSpreads : obj)
        ([<ExcelArgument(Name="swapIndexBase",Description = "Reference to swapIndexBase")>] 
         swapIndexBase : obj)
        ([<ExcelArgument(Name="shortSwapIndexBase",Description = "Reference to shortSwapIndexBase")>] 
         shortSwapIndexBase : obj)
        ([<ExcelArgument(Name="vegaWeightedSmileFit",Description = "Reference to vegaWeightedSmileFit")>] 
         vegaWeightedSmileFit : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _atmVolStructure = Helper.toHandle<SwaptionVolatilityStructure> atmVolStructure "atmVolStructure" 
                let _optionTenors = Helper.toCell<Generic.List<Period>> optionTenors "optionTenors" 
                let _swapTenors = Helper.toCell<Generic.List<Period>> swapTenors "swapTenors" 
                let _strikeSpreads = Helper.toCell<Generic.List<double>> strikeSpreads "strikeSpreads" 
                let _volSpreads = Helper.toCell<Generic.List<Generic.List<Handle<Quote>>>> volSpreads "volSpreads" 
                let _swapIndexBase = Helper.toCell<SwapIndex> swapIndexBase "swapIndexBase" 
                let _shortSwapIndexBase = Helper.toCell<SwapIndex> shortSwapIndexBase "shortSwapIndexBase" 
                let _vegaWeightedSmileFit = Helper.toCell<bool> vegaWeightedSmileFit "vegaWeightedSmileFit" 
                let builder () = withMnemonic mnemonic (Fun.SwaptionVolCube2 
                                                            _atmVolStructure.cell 
                                                            _optionTenors.cell 
                                                            _swapTenors.cell 
                                                            _strikeSpreads.cell 
                                                            _volSpreads.cell 
                                                            _swapIndexBase.cell 
                                                            _shortSwapIndexBase.cell 
                                                            _vegaWeightedSmileFit.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwaptionVolCube2>) l

                let source = Helper.sourceFold "Fun.SwaptionVolCube2" 
                                               [| _atmVolStructure.source
                                               ;  _optionTenors.source
                                               ;  _swapTenors.source
                                               ;  _strikeSpreads.source
                                               ;  _volSpreads.source
                                               ;  _swapIndexBase.source
                                               ;  _shortSwapIndexBase.source
                                               ;  _vegaWeightedSmileFit.source
                                               |]
                let hash = Helper.hashFold 
                                [| _atmVolStructure.cell
                                ;  _optionTenors.cell
                                ;  _swapTenors.cell
                                ;  _strikeSpreads.cell
                                ;  _volSpreads.cell
                                ;  _swapIndexBase.cell
                                ;  _shortSwapIndexBase.cell
                                ;  _vegaWeightedSmileFit.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionVolCube2> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        SwaptionVolatilityCube inspectors
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_volSpreads", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_volSpreads
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let _i = Helper.toCell<int> i "i" 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).VolSpreads
                                                            _i.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".VolSpreads") 
                                               [| _SwaptionVolCube2.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                ;  _i.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionVolCube2> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_atmStrike", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_atmStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).AtmStrike
                                                            _optionTenor.cell 
                                                            _swapTenor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".AtmStrike") 
                                               [| _SwaptionVolCube2.source
                                               ;  _optionTenor.source
                                               ;  _swapTenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                ;  _optionTenor.cell
                                ;  _swapTenor.cell
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
        Other inspectors
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_atmStrike", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_atmStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).AtmStrike1
                                                            _optionDate.cell 
                                                            _swapTenor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".AtmStrike") 
                                               [| _SwaptionVolCube2.source
                                               ;  _optionDate.source
                                               ;  _swapTenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                ;  _optionDate.cell
                                ;  _swapTenor.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube2_atmVol", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_atmVol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).AtmVol
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<SwaptionVolatilityStructure>>) l

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".AtmVol") 
                                               [| _SwaptionVolCube2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionVolCube2> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_calendar", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".Calendar") 
                                               [| _SwaptionVolCube2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionVolCube2> format
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
    [<ExcelFunction(Name="_SwaptionVolCube2_dayCounter", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".DayCounter") 
                                               [| _SwaptionVolCube2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionVolCube2> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_maxDate", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".MaxDate") 
                                               [| _SwaptionVolCube2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube2_maxStrike", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".MaxStrike") 
                                               [| _SwaptionVolCube2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
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
        SwaptionVolatilityStructure interface
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_maxSwapTenor", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_maxSwapTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).MaxSwapTenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".MaxSwapTenor") 
                                               [| _SwaptionVolCube2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionVolCube2> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_maxTime", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".MaxTime") 
                                               [| _SwaptionVolCube2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube2_minStrike", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".MinStrike") 
                                               [| _SwaptionVolCube2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube2_referenceDate", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".ReferenceDate") 
                                               [| _SwaptionVolCube2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube2_settlementDays", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".SettlementDays") 
                                               [| _SwaptionVolCube2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube2_shortSwapIndexBase", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_shortSwapIndexBase
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).ShortSwapIndexBase
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".ShortSwapIndexBase") 
                                               [| _SwaptionVolCube2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionVolCube2> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_strikeSpreads", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_strikeSpreads
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).StrikeSpreads
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".StrikeSpreads") 
                                               [| _SwaptionVolCube2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_swapIndexBase", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_swapIndexBase
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).SwapIndexBase
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SwapIndex>) l

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".SwapIndexBase") 
                                               [| _SwaptionVolCube2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionVolCube2> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_vegaWeightedSmileFit", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_vegaWeightedSmileFit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).VegaWeightedSmileFit
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".VegaWeightedSmileFit") 
                                               [| _SwaptionVolCube2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube2_volatilityType", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_volatilityType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).VolatilityType
                                                       ) :> ICell
                let format (o : VolatilityType) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".VolatilityType") 
                                               [| _SwaptionVolCube2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
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
        ! additional inspectors
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_optionDateFromTime", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_optionDateFromTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).OptionDateFromTime
                                                            _optionTime.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".OptionDateFromTime") 
                                               [| _SwaptionVolCube2.source
                                               ;  _optionTime.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                ;  _optionTime.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube2_optionDates", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_optionDates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).OptionDates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".OptionDates") 
                                               [| _SwaptionVolCube2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_optionTenors", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_optionTenors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).OptionTenors
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Period>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".OptionTenors") 
                                               [| _SwaptionVolCube2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_optionTimes", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_optionTimes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).OptionTimes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".OptionTimes") 
                                               [| _SwaptionVolCube2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_swapLengths", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_swapLengths
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).SwapLengths
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".SwapLengths") 
                                               [| _SwaptionVolCube2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_swapTenors", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_swapTenors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).SwapTenors
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Period>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".SwapTenors") 
                                               [| _SwaptionVolCube2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_update", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).Update
                                                       ) :> ICell
                let format (o : SwaptionVolCube2) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".Update") 
                                               [| _SwaptionVolCube2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
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
        ! returns the Black variance for a given option time and swap length
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_blackVariance", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_blackVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).BlackVariance
                                                            _optionTime.cell 
                                                            _swapLength.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".BlackVariance") 
                                               [| _SwaptionVolCube2.source
                                               ;  _optionTime.source
                                               ;  _swapLength.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                ;  _optionTime.cell
                                ;  _swapLength.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! returns the Black variance for a given option date and swap length
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_blackVariance", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_blackVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).BlackVariance1
                                                            _optionDate.cell 
                                                            _swapLength.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".BlackVariance") 
                                               [| _SwaptionVolCube2.source
                                               ;  _optionDate.source
                                               ;  _swapLength.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                ;  _optionDate.cell
                                ;  _swapLength.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! returns the Black variance for a given option tenor and swap length
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_blackVariance", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_blackVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).BlackVariance2
                                                            _optionTenor.cell 
                                                            _swapLength.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".BlackVariance") 
                                               [| _SwaptionVolCube2.source
                                               ;  _optionTenor.source
                                               ;  _swapLength.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                ;  _optionTenor.cell
                                ;  _swapLength.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! returns the Black variance for a given option time and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_blackVariance", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_blackVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).BlackVariance3
                                                            _optionTime.cell 
                                                            _swapTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".BlackVariance") 
                                               [| _SwaptionVolCube2.source
                                               ;  _optionTime.source
                                               ;  _swapTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                ;  _optionTime.cell
                                ;  _swapTenor.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! returns the Black variance for a given option date and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_blackVariance", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_blackVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).BlackVariance4
                                                            _optionDate.cell 
                                                            _swapTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".BlackVariance") 
                                               [| _SwaptionVolCube2.source
                                               ;  _optionDate.source
                                               ;  _swapTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                ;  _optionDate.cell
                                ;  _swapTenor.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! returns the Black variance for a given option tenor and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_blackVariance", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_blackVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).BlackVariance5
                                                            _optionTenor.cell 
                                                            _swapTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".BlackVariance") 
                                               [| _SwaptionVolCube2.source
                                               ;  _optionTenor.source
                                               ;  _swapTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                ;  _optionTenor.cell
                                ;  _swapTenor.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! the largest swapLength for which the term structure can return vols
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_maxSwapLength", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_maxSwapLength
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).MaxSwapLength
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".MaxSwapLength") 
                                               [| _SwaptionVolCube2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
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
        ! returns the shift for a given option time and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_shift", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_shift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).Shift
                                                            _optionTime.cell 
                                                            _swapTenor.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".Shift") 
                                               [| _SwaptionVolCube2.source
                                               ;  _optionTime.source
                                               ;  _swapTenor.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                ;  _optionTime.cell
                                ;  _swapTenor.cell
                                ;  _extrapolate.cell
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
        ! returns the shift for a given option date and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_shift", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_shift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).Shift1
                                                            _optionDate.cell 
                                                            _swapTenor.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".Shift") 
                                               [| _SwaptionVolCube2.source
                                               ;  _optionDate.source
                                               ;  _swapTenor.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                ;  _optionDate.cell
                                ;  _swapTenor.cell
                                ;  _extrapolate.cell
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
        ! returns the shift for a given option date and swap length
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_shift", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_shift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).Shift2
                                                            _optionDate.cell 
                                                            _swapLength.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".Shift") 
                                               [| _SwaptionVolCube2.source
                                               ;  _optionDate.source
                                               ;  _swapLength.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                ;  _optionDate.cell
                                ;  _swapLength.cell
                                ;  _extrapolate.cell
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
        ! returns the shift for a given option time and swap length
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_shift", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_shift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).Shift3
                                                            _optionTime.cell 
                                                            _swapLength.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".Shift") 
                                               [| _SwaptionVolCube2.source
                                               ;  _optionTime.source
                                               ;  _swapLength.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                ;  _optionTime.cell
                                ;  _swapLength.cell
                                ;  _extrapolate.cell
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
        ! returns the shift for a given option tenor and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_shift", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_shift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).Shift4
                                                            _optionTenor.cell 
                                                            _swapTenor.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".Shift") 
                                               [| _SwaptionVolCube2.source
                                               ;  _optionTenor.source
                                               ;  _swapTenor.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                ;  _optionTenor.cell
                                ;  _swapTenor.cell
                                ;  _extrapolate.cell
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
        ! returns the shift for a given option tenor and swap length
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_shift", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_shift
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).Shift5
                                                            _optionTenor.cell 
                                                            _swapLength.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".Shift") 
                                               [| _SwaptionVolCube2.source
                                               ;  _optionTenor.source
                                               ;  _swapLength.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                ;  _optionTenor.cell
                                ;  _swapLength.cell
                                ;  _extrapolate.cell
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
        ! returns the smile for a given option tenor and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_smileSection", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_smileSection
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="extr",Description = "Reference to extr")>] 
         extr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _extr = Helper.toCell<bool> extr "extr" 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).SmileSection
                                                            _optionTenor.cell 
                                                            _swapTenor.cell 
                                                            _extr.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SmileSection>) l

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".SmileSection") 
                                               [| _SwaptionVolCube2.source
                                               ;  _optionTenor.source
                                               ;  _swapTenor.source
                                               ;  _extr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                ;  _optionTenor.cell
                                ;  _swapTenor.cell
                                ;  _extr.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionVolCube2> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns the smile for a given option time and swap length
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_smileSection", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_smileSection
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="extr",Description = "Reference to extr")>] 
         extr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let _extr = Helper.toCell<bool> extr "extr" 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).SmileSection1
                                                            _optionTime.cell 
                                                            _swapLength.cell 
                                                            _extr.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SmileSection>) l

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".SmileSection") 
                                               [| _SwaptionVolCube2.source
                                               ;  _optionTime.source
                                               ;  _swapLength.source
                                               ;  _extr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                ;  _optionTime.cell
                                ;  _swapLength.cell
                                ;  _extr.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionVolCube2> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns the smile for a given option date and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_smileSection", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_smileSection
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="extr",Description = "Reference to extr")>] 
         extr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _extr = Helper.toCell<bool> extr "extr" 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).SmileSection2
                                                            _optionDate.cell 
                                                            _swapTenor.cell 
                                                            _extr.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SmileSection>) l

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".SmileSection") 
                                               [| _SwaptionVolCube2.source
                                               ;  _optionDate.source
                                               ;  _swapTenor.source
                                               ;  _extr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                ;  _optionDate.cell
                                ;  _swapTenor.cell
                                ;  _extr.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SwaptionVolCube2> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! implements the conversion between swap dates and swap (time) length
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_swapLength", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_swapLength
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        ([<ExcelArgument(Name="start",Description = "Reference to start")>] 
         start : obj)
        ([<ExcelArgument(Name="End",Description = "Reference to End")>] 
         End : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let _start = Helper.toCell<Date> start "start" 
                let _End = Helper.toCell<Date> End "End" 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).SwapLength
                                                            _start.cell 
                                                            _End.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".SwapLength") 
                                               [| _SwaptionVolCube2.source
                                               ;  _start.source
                                               ;  _End.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                ;  _start.cell
                                ;  _End.cell
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
        ! implements the conversion between swap tenor and swap (time) length
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_swapLength", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_swapLength
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).SwapLength1
                                                            _swapTenor.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".SwapLength") 
                                               [| _SwaptionVolCube2.source
                                               ;  _swapTenor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                ;  _swapTenor.cell
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
        ! returns the volatility for a given option date and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_volatility", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).Volatility
                                                            _optionDate.cell 
                                                            _swapTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".Volatility") 
                                               [| _SwaptionVolCube2.source
                                               ;  _optionDate.source
                                               ;  _swapTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                ;  _optionDate.cell
                                ;  _swapTenor.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! returns the volatility for a given option date and swap length
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_volatility", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).Volatility1
                                                            _optionDate.cell 
                                                            _swapLength.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".Volatility") 
                                               [| _SwaptionVolCube2.source
                                               ;  _optionDate.source
                                               ;  _swapLength.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                ;  _optionDate.cell
                                ;  _swapLength.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! returns the volatility for a given option tenor and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_volatility", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).Volatility2
                                                            _optionTenor.cell 
                                                            _swapTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".Volatility") 
                                               [| _SwaptionVolCube2.source
                                               ;  _optionTenor.source
                                               ;  _swapTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                ;  _optionTenor.cell
                                ;  _swapTenor.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! returns the volatility for a given option tenor and swap length
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_volatility", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).Volatility3
                                                            _optionTenor.cell 
                                                            _swapLength.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".Volatility") 
                                               [| _SwaptionVolCube2.source
                                               ;  _optionTenor.source
                                               ;  _swapLength.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                ;  _optionTenor.cell
                                ;  _swapLength.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! returns the volatility for a given option time and swap length
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_volatility", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapLength",Description = "Reference to swapLength")>] 
         swapLength : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let _swapLength = Helper.toCell<double> swapLength "swapLength" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).Volatility4
                                                            _optionTime.cell 
                                                            _swapLength.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".Volatility") 
                                               [| _SwaptionVolCube2.source
                                               ;  _optionTime.source
                                               ;  _swapLength.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                ;  _optionTime.cell
                                ;  _swapLength.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! returns the volatility for a given option time and swap tenor
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_volatility", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="swapTenor",Description = "Reference to swapTenor")>] 
         swapTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let _swapTenor = Helper.toCell<Period> swapTenor "swapTenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).Volatility5
                                                            _optionTime.cell 
                                                            _swapTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".Volatility") 
                                               [| _SwaptionVolCube2.source
                                               ;  _optionTime.source
                                               ;  _swapTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                ;  _optionTime.cell
                                ;  _swapTenor.cell
                                ;  _strike.cell
                                ;  _extrapolate.cell
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
        ! the business day convention used in tenor to date conversion
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_businessDayConvention", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".BusinessDayConvention") 
                                               [| _SwaptionVolCube2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
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
        ! period/date conversion
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_optionDateFromTenor", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_optionDateFromTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let _p = Helper.toCell<Period> p "p" 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).OptionDateFromTenor
                                                            _p.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".OptionDateFromTenor") 
                                               [| _SwaptionVolCube2.source
                                               ;  _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
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
        ! date/time conversion
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_timeFromReference", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let _date = Helper.toCell<Date> date "date" 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".TimeFromReference") 
                                               [| _SwaptionVolCube2.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                ;  _date.cell
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
        some extra functionality
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_allowsExtrapolation", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".AllowsExtrapolation") 
                                               [| _SwaptionVolCube2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
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
        ! enable extrapolation in subsequent calls
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_disableExtrapolation", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : SwaptionVolCube2) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".DisableExtrapolation") 
                                               [| _SwaptionVolCube2.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                ;  _b.cell
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
        ! tells whether extrapolation is enabled
    *)
    [<ExcelFunction(Name="_SwaptionVolCube2_enableExtrapolation", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : SwaptionVolCube2) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".EnableExtrapolation") 
                                               [| _SwaptionVolCube2.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
                                ;  _b.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube2_extrapolate", Description="Create a SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SwaptionVolCube2",Description = "Reference to SwaptionVolCube2")>] 
         swaptionvolcube2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SwaptionVolCube2 = Helper.toCell<SwaptionVolCube2> swaptionvolcube2 "SwaptionVolCube2"  
                let builder () = withMnemonic mnemonic ((_SwaptionVolCube2.cell :?> SwaptionVolCube2Model).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SwaptionVolCube2.source + ".Extrapolate") 
                                               [| _SwaptionVolCube2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SwaptionVolCube2.cell
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
    [<ExcelFunction(Name="_SwaptionVolCube2_Range", Description="Create a range of SwaptionVolCube2",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SwaptionVolCube2_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the SwaptionVolCube2")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SwaptionVolCube2> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SwaptionVolCube2>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<SwaptionVolCube2>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<SwaptionVolCube2>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)