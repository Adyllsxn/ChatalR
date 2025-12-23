import PageList from "@/components/common/home/page-list";
import RecentList from "@/components/common/home/recent list";
import Header from "@/components/layouts/Header";
import { DATA } from "@/utils/data";
import { View, ScrollView } from "react-native";

export default function HomeScreen(){
    return(
        <View style={{flex:1, paddingTop: 32}}>
            <Header />

            <ScrollView showsVerticalScrollIndicator={false} contentContainerStyle={{paddingTop: 24, paddingBottom: 100}}>
                <RecentList data={DATA.RECENT} />
                <PageList data={DATA.PAGES} />
            </ScrollView>
            
        </View>
    )
}