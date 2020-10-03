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
module StrippedOptionletAdapterFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_StrippedOptionletAdapter_displacement", Description="Create a StrippedOptionletAdapter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StrippedOptionletAdapter_displacement
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StrippedOptionletAdapter",Description = "Reference to StrippedOptionletAdapter")>] 
         strippedoptionletadapter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StrippedOptionletAdapter = Helper.toCell<StrippedOptionletAdapter> strippedoptionletadapter "StrippedOptionletAdapter"  
                let builder () = withMnemonic mnemonic ((_StrippedOptionletAdapter.cell :?> StrippedOptionletAdapterModel).Displacement
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_StrippedOptionletAdapter.source + ".Displacement") 
                                               [| _StrippedOptionletAdapter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StrippedOptionletAdapter.cell
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
    [<ExcelFunction(Name="_StrippedOptionletAdapter_maxDate", Description="Create a StrippedOptionletAdapter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StrippedOptionletAdapter_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StrippedOptionletAdapter",Description = "Reference to StrippedOptionletAdapter")>] 
         strippedoptionletadapter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StrippedOptionletAdapter = Helper.toCell<StrippedOptionletAdapter> strippedoptionletadapter "StrippedOptionletAdapter"  
                let builder () = withMnemonic mnemonic ((_StrippedOptionletAdapter.cell :?> StrippedOptionletAdapterModel).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_StrippedOptionletAdapter.source + ".MaxDate") 
                                               [| _StrippedOptionletAdapter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StrippedOptionletAdapter.cell
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
    [<ExcelFunction(Name="_StrippedOptionletAdapter_maxStrike", Description="Create a StrippedOptionletAdapter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StrippedOptionletAdapter_maxStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StrippedOptionletAdapter",Description = "Reference to StrippedOptionletAdapter")>] 
         strippedoptionletadapter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StrippedOptionletAdapter = Helper.toCell<StrippedOptionletAdapter> strippedoptionletadapter "StrippedOptionletAdapter"  
                let builder () = withMnemonic mnemonic ((_StrippedOptionletAdapter.cell :?> StrippedOptionletAdapterModel).MaxStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_StrippedOptionletAdapter.source + ".MaxStrike") 
                                               [| _StrippedOptionletAdapter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StrippedOptionletAdapter.cell
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
    [<ExcelFunction(Name="_StrippedOptionletAdapter_minStrike", Description="Create a StrippedOptionletAdapter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StrippedOptionletAdapter_minStrike
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StrippedOptionletAdapter",Description = "Reference to StrippedOptionletAdapter")>] 
         strippedoptionletadapter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StrippedOptionletAdapter = Helper.toCell<StrippedOptionletAdapter> strippedoptionletadapter "StrippedOptionletAdapter"  
                let builder () = withMnemonic mnemonic ((_StrippedOptionletAdapter.cell :?> StrippedOptionletAdapterModel).MinStrike
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_StrippedOptionletAdapter.source + ".MinStrike") 
                                               [| _StrippedOptionletAdapter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StrippedOptionletAdapter.cell
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
        ! Adapter class for turning a StrippedOptionletBase obj into an OptionletVolatilityStructure.
    *)
    [<ExcelFunction(Name="_StrippedOptionletAdapter", Description="Create a StrippedOptionletAdapter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StrippedOptionletAdapter_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="s",Description = "Reference to s")>] 
         s : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _s = Helper.toCell<StrippedOptionletBase> s "s" 
                let builder () = withMnemonic mnemonic (Fun.StrippedOptionletAdapter 
                                                            _s.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<StrippedOptionletAdapter>) l

                let source = Helper.sourceFold "Fun.StrippedOptionletAdapter" 
                                               [| _s.source
                                               |]
                let hash = Helper.hashFold 
                                [| _s.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<StrippedOptionletAdapter> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        LazyObject interface
    *)
    [<ExcelFunction(Name="_StrippedOptionletAdapter_update", Description="Create a StrippedOptionletAdapter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StrippedOptionletAdapter_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StrippedOptionletAdapter",Description = "Reference to StrippedOptionletAdapter")>] 
         strippedoptionletadapter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StrippedOptionletAdapter = Helper.toCell<StrippedOptionletAdapter> strippedoptionletadapter "StrippedOptionletAdapter"  
                let builder () = withMnemonic mnemonic ((_StrippedOptionletAdapter.cell :?> StrippedOptionletAdapterModel).Update
                                                       ) :> ICell
                let format (o : StrippedOptionletAdapter) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_StrippedOptionletAdapter.source + ".Update") 
                                               [| _StrippedOptionletAdapter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StrippedOptionletAdapter.cell
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
    [<ExcelFunction(Name="_StrippedOptionletAdapter_volatilityType", Description="Create a StrippedOptionletAdapter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StrippedOptionletAdapter_volatilityType
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StrippedOptionletAdapter",Description = "Reference to StrippedOptionletAdapter")>] 
         strippedoptionletadapter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StrippedOptionletAdapter = Helper.toCell<StrippedOptionletAdapter> strippedoptionletadapter "StrippedOptionletAdapter"  
                let builder () = withMnemonic mnemonic ((_StrippedOptionletAdapter.cell :?> StrippedOptionletAdapterModel).VolatilityType
                                                       ) :> ICell
                let format (o : VolatilityType) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_StrippedOptionletAdapter.source + ".VolatilityType") 
                                               [| _StrippedOptionletAdapter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StrippedOptionletAdapter.cell
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
        ! returns the Black variance for a given option time and strike rate
    *)
    [<ExcelFunction(Name="_StrippedOptionletAdapter_blackVariance", Description="Create a StrippedOptionletAdapter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StrippedOptionletAdapter_blackVariance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StrippedOptionletAdapter",Description = "Reference to StrippedOptionletAdapter")>] 
         strippedoptionletadapter : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StrippedOptionletAdapter = Helper.toCell<StrippedOptionletAdapter> strippedoptionletadapter "StrippedOptionletAdapter"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_StrippedOptionletAdapter.cell :?> StrippedOptionletAdapterModel).BlackVariance
                                                            _optionTime.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_StrippedOptionletAdapter.source + ".BlackVariance") 
                                               [| _StrippedOptionletAdapter.source
                                               ;  _optionTime.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StrippedOptionletAdapter.cell
                                ;  _optionTime.cell
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
        ! returns the Black variance for a given option tenor and strike rate
    *)
    [<ExcelFunction(Name="_StrippedOptionletAdapter_blackVariance2", Description="Create a StrippedOptionletAdapter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StrippedOptionletAdapter_blackVariance2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StrippedOptionletAdapter",Description = "Reference to StrippedOptionletAdapter")>] 
         strippedoptionletadapter : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StrippedOptionletAdapter = Helper.toCell<StrippedOptionletAdapter> strippedoptionletadapter "StrippedOptionletAdapter"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_StrippedOptionletAdapter.cell :?> StrippedOptionletAdapterModel).BlackVariance2
                                                            _optionTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_StrippedOptionletAdapter.source + ".BlackVariance2") 
                                               [| _StrippedOptionletAdapter.source
                                               ;  _optionTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StrippedOptionletAdapter.cell
                                ;  _optionTenor.cell
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
        ! returns the Black variance for a given option date and strike rate
    *)
    [<ExcelFunction(Name="_StrippedOptionletAdapter_blackVariance1", Description="Create a StrippedOptionletAdapter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StrippedOptionletAdapter_blackVariance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StrippedOptionletAdapter",Description = "Reference to StrippedOptionletAdapter")>] 
         strippedoptionletadapter : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StrippedOptionletAdapter = Helper.toCell<StrippedOptionletAdapter> strippedoptionletadapter "StrippedOptionletAdapter"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_StrippedOptionletAdapter.cell :?> StrippedOptionletAdapterModel).BlackVariance1
                                                            _optionDate.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_StrippedOptionletAdapter.source + ".BlackVariance1") 
                                               [| _StrippedOptionletAdapter.source
                                               ;  _optionDate.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StrippedOptionletAdapter.cell
                                ;  _optionDate.cell
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
        ! returns the smile for a given option time
    *)
    [<ExcelFunction(Name="_StrippedOptionletAdapter_smileSection", Description="Create a StrippedOptionletAdapter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StrippedOptionletAdapter_smileSection
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StrippedOptionletAdapter",Description = "Reference to StrippedOptionletAdapter")>] 
         strippedoptionletadapter : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="extr",Description = "Reference to extr")>] 
         extr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StrippedOptionletAdapter = Helper.toCell<StrippedOptionletAdapter> strippedoptionletadapter "StrippedOptionletAdapter"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let _extr = Helper.toCell<bool> extr "extr" 
                let builder () = withMnemonic mnemonic ((_StrippedOptionletAdapter.cell :?> StrippedOptionletAdapterModel).SmileSection
                                                            _optionTime.cell 
                                                            _extr.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SmileSection>) l

                let source = Helper.sourceFold (_StrippedOptionletAdapter.source + ".SmileSection") 
                                               [| _StrippedOptionletAdapter.source
                                               ;  _optionTime.source
                                               ;  _extr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StrippedOptionletAdapter.cell
                                ;  _optionTime.cell
                                ;  _extr.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<StrippedOptionletAdapter> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns the smile for a given option date
    *)
    [<ExcelFunction(Name="_StrippedOptionletAdapter_smileSection2", Description="Create a StrippedOptionletAdapter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StrippedOptionletAdapter_smileSection2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StrippedOptionletAdapter",Description = "Reference to StrippedOptionletAdapter")>] 
         strippedoptionletadapter : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="extr",Description = "Reference to extr")>] 
         extr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StrippedOptionletAdapter = Helper.toCell<StrippedOptionletAdapter> strippedoptionletadapter "StrippedOptionletAdapter"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _extr = Helper.toCell<bool> extr "extr" 
                let builder () = withMnemonic mnemonic ((_StrippedOptionletAdapter.cell :?> StrippedOptionletAdapterModel).SmileSection2
                                                            _optionDate.cell 
                                                            _extr.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SmileSection>) l

                let source = Helper.sourceFold (_StrippedOptionletAdapter.source + ".SmileSection2") 
                                               [| _StrippedOptionletAdapter.source
                                               ;  _optionDate.source
                                               ;  _extr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StrippedOptionletAdapter.cell
                                ;  _optionDate.cell
                                ;  _extr.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<StrippedOptionletAdapter> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns the smile for a given option tenor
    *)
    [<ExcelFunction(Name="_StrippedOptionletAdapter_smileSection1", Description="Create a StrippedOptionletAdapter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StrippedOptionletAdapter_smileSection1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StrippedOptionletAdapter",Description = "Reference to StrippedOptionletAdapter")>] 
         strippedoptionletadapter : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="extr",Description = "Reference to extr")>] 
         extr : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StrippedOptionletAdapter = Helper.toCell<StrippedOptionletAdapter> strippedoptionletadapter "StrippedOptionletAdapter"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _extr = Helper.toCell<bool> extr "extr" 
                let builder () = withMnemonic mnemonic ((_StrippedOptionletAdapter.cell :?> StrippedOptionletAdapterModel).SmileSection1
                                                            _optionTenor.cell 
                                                            _extr.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SmileSection>) l

                let source = Helper.sourceFold (_StrippedOptionletAdapter.source + ".SmileSection1") 
                                               [| _StrippedOptionletAdapter.source
                                               ;  _optionTenor.source
                                               ;  _extr.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StrippedOptionletAdapter.cell
                                ;  _optionTenor.cell
                                ;  _extr.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<StrippedOptionletAdapter> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns the volatility for a given option time and strike rate
    *)
    [<ExcelFunction(Name="_StrippedOptionletAdapter_volatility2", Description="Create a StrippedOptionletAdapter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StrippedOptionletAdapter_volatility2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StrippedOptionletAdapter",Description = "Reference to StrippedOptionletAdapter")>] 
         strippedoptionletadapter : obj)
        ([<ExcelArgument(Name="optionTime",Description = "Reference to optionTime")>] 
         optionTime : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StrippedOptionletAdapter = Helper.toCell<StrippedOptionletAdapter> strippedoptionletadapter "StrippedOptionletAdapter"  
                let _optionTime = Helper.toCell<double> optionTime "optionTime" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_StrippedOptionletAdapter.cell :?> StrippedOptionletAdapterModel).Volatility2
                                                            _optionTime.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_StrippedOptionletAdapter.source + ".Volatility2") 
                                               [| _StrippedOptionletAdapter.source
                                               ;  _optionTime.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StrippedOptionletAdapter.cell
                                ;  _optionTime.cell
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
        ! returns the volatility for a given option date and strike rate
    *)
    [<ExcelFunction(Name="_StrippedOptionletAdapter_volatility1", Description="Create a StrippedOptionletAdapter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StrippedOptionletAdapter_volatility1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StrippedOptionletAdapter",Description = "Reference to StrippedOptionletAdapter")>] 
         strippedoptionletadapter : obj)
        ([<ExcelArgument(Name="optionDate",Description = "Reference to optionDate")>] 
         optionDate : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StrippedOptionletAdapter = Helper.toCell<StrippedOptionletAdapter> strippedoptionletadapter "StrippedOptionletAdapter"  
                let _optionDate = Helper.toCell<Date> optionDate "optionDate" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_StrippedOptionletAdapter.cell :?> StrippedOptionletAdapterModel).Volatility1
                                                            _optionDate.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_StrippedOptionletAdapter.source + ".Volatility1") 
                                               [| _StrippedOptionletAdapter.source
                                               ;  _optionDate.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StrippedOptionletAdapter.cell
                                ;  _optionDate.cell
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
        ! returns the volatility for a given option tenor and strike rate
    *)
    [<ExcelFunction(Name="_StrippedOptionletAdapter_volatility", Description="Create a StrippedOptionletAdapter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StrippedOptionletAdapter_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StrippedOptionletAdapter",Description = "Reference to StrippedOptionletAdapter")>] 
         strippedoptionletadapter : obj)
        ([<ExcelArgument(Name="optionTenor",Description = "Reference to optionTenor")>] 
         optionTenor : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="extrapolate",Description = "Reference to extrapolate")>] 
         extrapolate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StrippedOptionletAdapter = Helper.toCell<StrippedOptionletAdapter> strippedoptionletadapter "StrippedOptionletAdapter"  
                let _optionTenor = Helper.toCell<Period> optionTenor "optionTenor" 
                let _strike = Helper.toCell<double> strike "strike" 
                let _extrapolate = Helper.toCell<bool> extrapolate "extrapolate" 
                let builder () = withMnemonic mnemonic ((_StrippedOptionletAdapter.cell :?> StrippedOptionletAdapterModel).Volatility
                                                            _optionTenor.cell 
                                                            _strike.cell 
                                                            _extrapolate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_StrippedOptionletAdapter.source + ".Volatility") 
                                               [| _StrippedOptionletAdapter.source
                                               ;  _optionTenor.source
                                               ;  _strike.source
                                               ;  _extrapolate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StrippedOptionletAdapter.cell
                                ;  _optionTenor.cell
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
    [<ExcelFunction(Name="_StrippedOptionletAdapter_businessDayConvention", Description="Create a StrippedOptionletAdapter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StrippedOptionletAdapter_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StrippedOptionletAdapter",Description = "Reference to StrippedOptionletAdapter")>] 
         strippedoptionletadapter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StrippedOptionletAdapter = Helper.toCell<StrippedOptionletAdapter> strippedoptionletadapter "StrippedOptionletAdapter"  
                let builder () = withMnemonic mnemonic ((_StrippedOptionletAdapter.cell :?> StrippedOptionletAdapterModel).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_StrippedOptionletAdapter.source + ".BusinessDayConvention") 
                                               [| _StrippedOptionletAdapter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StrippedOptionletAdapter.cell
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
    [<ExcelFunction(Name="_StrippedOptionletAdapter_optionDateFromTenor", Description="Create a StrippedOptionletAdapter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StrippedOptionletAdapter_optionDateFromTenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StrippedOptionletAdapter",Description = "Reference to StrippedOptionletAdapter")>] 
         strippedoptionletadapter : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StrippedOptionletAdapter = Helper.toCell<StrippedOptionletAdapter> strippedoptionletadapter "StrippedOptionletAdapter"  
                let _p = Helper.toCell<Period> p "p" 
                let builder () = withMnemonic mnemonic ((_StrippedOptionletAdapter.cell :?> StrippedOptionletAdapterModel).OptionDateFromTenor
                                                            _p.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_StrippedOptionletAdapter.source + ".OptionDateFromTenor") 
                                               [| _StrippedOptionletAdapter.source
                                               ;  _p.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StrippedOptionletAdapter.cell
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
        ! the calendar used for reference and/or option date calculation
    *)
    [<ExcelFunction(Name="_StrippedOptionletAdapter_calendar", Description="Create a StrippedOptionletAdapter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StrippedOptionletAdapter_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StrippedOptionletAdapter",Description = "Reference to StrippedOptionletAdapter")>] 
         strippedoptionletadapter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StrippedOptionletAdapter = Helper.toCell<StrippedOptionletAdapter> strippedoptionletadapter "StrippedOptionletAdapter"  
                let builder () = withMnemonic mnemonic ((_StrippedOptionletAdapter.cell :?> StrippedOptionletAdapterModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_StrippedOptionletAdapter.source + ".Calendar") 
                                               [| _StrippedOptionletAdapter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StrippedOptionletAdapter.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<StrippedOptionletAdapter> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! the day counter used for date/time conversion
    *)
    [<ExcelFunction(Name="_StrippedOptionletAdapter_dayCounter", Description="Create a StrippedOptionletAdapter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StrippedOptionletAdapter_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StrippedOptionletAdapter",Description = "Reference to StrippedOptionletAdapter")>] 
         strippedoptionletadapter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StrippedOptionletAdapter = Helper.toCell<StrippedOptionletAdapter> strippedoptionletadapter "StrippedOptionletAdapter"  
                let builder () = withMnemonic mnemonic ((_StrippedOptionletAdapter.cell :?> StrippedOptionletAdapterModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_StrippedOptionletAdapter.source + ".DayCounter") 
                                               [| _StrippedOptionletAdapter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StrippedOptionletAdapter.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<StrippedOptionletAdapter> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! the latest time for which the curve can return values
    *)
    [<ExcelFunction(Name="_StrippedOptionletAdapter_maxTime", Description="Create a StrippedOptionletAdapter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StrippedOptionletAdapter_maxTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StrippedOptionletAdapter",Description = "Reference to StrippedOptionletAdapter")>] 
         strippedoptionletadapter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StrippedOptionletAdapter = Helper.toCell<StrippedOptionletAdapter> strippedoptionletadapter "StrippedOptionletAdapter"  
                let builder () = withMnemonic mnemonic ((_StrippedOptionletAdapter.cell :?> StrippedOptionletAdapterModel).MaxTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_StrippedOptionletAdapter.source + ".MaxTime") 
                                               [| _StrippedOptionletAdapter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StrippedOptionletAdapter.cell
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
        ! the date at which discount = 1.0 and/or variance = 0.0
    *)
    [<ExcelFunction(Name="_StrippedOptionletAdapter_referenceDate", Description="Create a StrippedOptionletAdapter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StrippedOptionletAdapter_referenceDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StrippedOptionletAdapter",Description = "Reference to StrippedOptionletAdapter")>] 
         strippedoptionletadapter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StrippedOptionletAdapter = Helper.toCell<StrippedOptionletAdapter> strippedoptionletadapter "StrippedOptionletAdapter"  
                let builder () = withMnemonic mnemonic ((_StrippedOptionletAdapter.cell :?> StrippedOptionletAdapterModel).ReferenceDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_StrippedOptionletAdapter.source + ".ReferenceDate") 
                                               [| _StrippedOptionletAdapter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StrippedOptionletAdapter.cell
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
        ! the settlementDays used for reference date calculation
    *)
    [<ExcelFunction(Name="_StrippedOptionletAdapter_settlementDays", Description="Create a StrippedOptionletAdapter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StrippedOptionletAdapter_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StrippedOptionletAdapter",Description = "Reference to StrippedOptionletAdapter")>] 
         strippedoptionletadapter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StrippedOptionletAdapter = Helper.toCell<StrippedOptionletAdapter> strippedoptionletadapter "StrippedOptionletAdapter"  
                let builder () = withMnemonic mnemonic ((_StrippedOptionletAdapter.cell :?> StrippedOptionletAdapterModel).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_StrippedOptionletAdapter.source + ".SettlementDays") 
                                               [| _StrippedOptionletAdapter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StrippedOptionletAdapter.cell
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
    [<ExcelFunction(Name="_StrippedOptionletAdapter_timeFromReference", Description="Create a StrippedOptionletAdapter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StrippedOptionletAdapter_timeFromReference
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StrippedOptionletAdapter",Description = "Reference to StrippedOptionletAdapter")>] 
         strippedoptionletadapter : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StrippedOptionletAdapter = Helper.toCell<StrippedOptionletAdapter> strippedoptionletadapter "StrippedOptionletAdapter"  
                let _date = Helper.toCell<Date> date "date" 
                let builder () = withMnemonic mnemonic ((_StrippedOptionletAdapter.cell :?> StrippedOptionletAdapterModel).TimeFromReference
                                                            _date.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_StrippedOptionletAdapter.source + ".TimeFromReference") 
                                               [| _StrippedOptionletAdapter.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StrippedOptionletAdapter.cell
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
    [<ExcelFunction(Name="_StrippedOptionletAdapter_allowsExtrapolation", Description="Create a StrippedOptionletAdapter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StrippedOptionletAdapter_allowsExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StrippedOptionletAdapter",Description = "Reference to StrippedOptionletAdapter")>] 
         strippedoptionletadapter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StrippedOptionletAdapter = Helper.toCell<StrippedOptionletAdapter> strippedoptionletadapter "StrippedOptionletAdapter"  
                let builder () = withMnemonic mnemonic ((_StrippedOptionletAdapter.cell :?> StrippedOptionletAdapterModel).AllowsExtrapolation
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_StrippedOptionletAdapter.source + ".AllowsExtrapolation") 
                                               [| _StrippedOptionletAdapter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StrippedOptionletAdapter.cell
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
    [<ExcelFunction(Name="_StrippedOptionletAdapter_disableExtrapolation", Description="Create a StrippedOptionletAdapter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StrippedOptionletAdapter_disableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StrippedOptionletAdapter",Description = "Reference to StrippedOptionletAdapter")>] 
         strippedoptionletadapter : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StrippedOptionletAdapter = Helper.toCell<StrippedOptionletAdapter> strippedoptionletadapter "StrippedOptionletAdapter"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((_StrippedOptionletAdapter.cell :?> StrippedOptionletAdapterModel).DisableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : StrippedOptionletAdapter) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_StrippedOptionletAdapter.source + ".DisableExtrapolation") 
                                               [| _StrippedOptionletAdapter.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StrippedOptionletAdapter.cell
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
    [<ExcelFunction(Name="_StrippedOptionletAdapter_enableExtrapolation", Description="Create a StrippedOptionletAdapter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StrippedOptionletAdapter_enableExtrapolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StrippedOptionletAdapter",Description = "Reference to StrippedOptionletAdapter")>] 
         strippedoptionletadapter : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StrippedOptionletAdapter = Helper.toCell<StrippedOptionletAdapter> strippedoptionletadapter "StrippedOptionletAdapter"  
                let _b = Helper.toCell<bool> b "b" 
                let builder () = withMnemonic mnemonic ((_StrippedOptionletAdapter.cell :?> StrippedOptionletAdapterModel).EnableExtrapolation
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : StrippedOptionletAdapter) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_StrippedOptionletAdapter.source + ".EnableExtrapolation") 
                                               [| _StrippedOptionletAdapter.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StrippedOptionletAdapter.cell
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
    [<ExcelFunction(Name="_StrippedOptionletAdapter_extrapolate", Description="Create a StrippedOptionletAdapter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StrippedOptionletAdapter_extrapolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="StrippedOptionletAdapter",Description = "Reference to StrippedOptionletAdapter")>] 
         strippedoptionletadapter : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _StrippedOptionletAdapter = Helper.toCell<StrippedOptionletAdapter> strippedoptionletadapter "StrippedOptionletAdapter"  
                let builder () = withMnemonic mnemonic ((_StrippedOptionletAdapter.cell :?> StrippedOptionletAdapterModel).Extrapolate
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_StrippedOptionletAdapter.source + ".Extrapolate") 
                                               [| _StrippedOptionletAdapter.source
                                               |]
                let hash = Helper.hashFold 
                                [| _StrippedOptionletAdapter.cell
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
    [<ExcelFunction(Name="_StrippedOptionletAdapter_Range", Description="Create a range of StrippedOptionletAdapter",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let StrippedOptionletAdapter_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the StrippedOptionletAdapter")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<StrippedOptionletAdapter> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<StrippedOptionletAdapter>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<StrippedOptionletAdapter>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<StrippedOptionletAdapter>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"